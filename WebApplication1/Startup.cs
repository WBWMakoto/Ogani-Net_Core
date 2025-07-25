﻿using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using WebApplication1.IdentityServer;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IVnPayService, VnPayService>(); // thêm dịch vụ VnPayService vào DI container
            services.AddDistributedMemoryCache(); // Lưu trữ Session trong bộ nhớ
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian timeout của Session
                options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP
                options.Cookie.IsEssential = true; // Cookie cần thiết, không cần đồng ý GDPR
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContextPool<ManageAppDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ManageUser, IdentityRole>() // để cho nó dùng được UserManger và roleManager
                .AddEntityFrameworkStores<ManageAppDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

            }) //https://nhatkyhoctap.blogspot.com/2017/09/identity-server-4-su-dung-sigining.html
          .AddInMemoryApiResources(Config.Apis) // bên folder IdentityServer thêm Config
                                                // .AddInMemoryClients(Configuration.GetSection("IdentityServer:Clients"))
          .AddInMemoryClients(Config.Clients) // lấy ra các client
          .AddInMemoryIdentityResources(Config.Ids)

          .AddInMemoryApiScopes(Config.ApiScopes)
          .AddAspNetIdentity<ManageUser>()
          .AddDeveloperSigningCredential();


            services.AddTransient<IEmailSender, EmailSenderService>();

            services.AddAuthentication()
                 .AddGoogle(googleOptions =>
                 {
                     // Đọc thông tin Authentication:Google từ appsettings.json
                     IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                  
                     // Thiết lập ClientID và ClientSecret để truy cập API google
                     googleOptions.ClientId = googleAuthNSection["ClientId"];
                     googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];

                 }).AddFacebook(facebookOptions => {
                     // Đọc cấu hình
                     IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                     facebookOptions.AppId = facebookAuthNSection["AppId"];
                     facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                     // Thiết lập đường dẫn Facebook chuyển hướng đến
                     facebookOptions.CallbackPath = "/sigin-facbook";
                 })
             .AddLocalApi("Bearer", option =>
             {
                 option.ExpectedScope = "api.WebApp";
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>  // thêm một cái chính sách
                {
                    policy.AddAuthenticationSchemes("Bearer"); 
                    policy.RequireAuthenticatedUser(); 
                });
            });

            services.AddRazorPages(options =>
            {
                options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
                {
                    foreach (var selector in model.Selectors)
                    {
                        var attributeRouteModel = selector.AttributeRouteModel;
                        attributeRouteModel.Order = -1;
                        attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
                    }
                });
            });


            services.AddControllersWithViews();


            services.AddTransient<IEmailSender, EmailSenderService>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IViewRenderService, ViewRenderService>();
            services.AddTransient<ICacheService, DistributedCacheService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp Space Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(Configuration["AuthorityUrl"] + "/connect/authorize"),
                            Scopes = new Dictionary<string, string> { { "api.WebApp", "WebApp API" } }
                        },
                    },
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "api.WebApp" }
                    }
                });


            });


            services.AddDistributedSqlServerCache(o =>
            {
                o.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                o.SchemaName = "dbo";
                o.TableName = "CacheTable";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new System.Globalization.CultureInfo("vi-VN");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseIdentityServer();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Đăng ký route cho Areas (Admin)
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // Route mặc định cho ứng dụng
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp Space Api V1");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                CreateAdminAccount(serviceProvider).Wait(); // Gọi Wait() để chặn cho đến khi Task hoàn thành
            }

        }

        private async Task CreateAdminAccount(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ManageUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "admin@admin.com";
            string adminPassword = "Admin@123";

            // Kiểm tra xem vai trò "Admin" đã tồn tại chưa
            var roleExist = await roleManager.FindByNameAsync("Admin");
            if (roleExist == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Kiểm tra xem tài khoản admin đã tồn tại chưa
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ManageUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }


}

