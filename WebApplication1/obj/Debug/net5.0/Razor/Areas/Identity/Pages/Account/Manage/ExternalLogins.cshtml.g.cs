#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b4077"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_ExternalLogins), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/ExternalLogins.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 2 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\_ViewImports.cshtml"
using WebApplication1.Areas.Identity

#nullable disable
    ;
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\_ViewImports.cshtml"
using WebApplication1.Areas.Identity.Pages

#nullable disable
    ;
#nullable restore
#line 5 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\_ViewImports.cshtml"
using WebApplication1.Data.Entities

#nullable disable
    ;
#nullable restore
#line 1 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using WebApplication1.Areas.Identity.Pages.Account

#nullable disable
    ;
#nullable restore
#line 1 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using WebApplication1.Areas.Identity.Pages.Account.Manage

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b4077", @"/Areas/Identity/Pages/Account/Manage/ExternalLogins.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c048d9e345094ddb01ae01e669e7f66e497939e36a30b05fffced62c098288a5", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"329aeeaedfd2631b274bdab61781c87eafbc960a487846b5e8f774fadd95b5ef", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"7aac8dbf79c9317b5921b2ceb1fce203abf4cd9553a48ffbf360431980994df0", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Pages_Account_Manage_ExternalLogins : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "LoginProvider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ProviderKey", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "RemoveLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("link-login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "LinkLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
  
    ViewData["Title"] = "Quản lý đăng nhập bên ngoài";
    ViewData["ActivePage"] = ManageNavPages.ExternalLogins;

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container mt-4\">\r\n    <div class=\"card shadow-lg p-4\">\r\n        <h2 class=\"text-center text-primary\">\r\n            <i class=\"fas fa-user-lock\"></i> ");
            Write(
#nullable restore
#line 11 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                              ViewData["Title"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </h2>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b40779007", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.
#nullable restore
#line 13 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                            StatusMessage

#line default
#line hidden
#nullable disable
            );
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 15 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
         if (Model.CurrentLogins?.Count > 0)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral(@"            <h4 class=""mt-3"">Tài khoản đã liên kết</h4>
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>Nhà cung cấp</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 26 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                     foreach (var login in Model.CurrentLogins)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <tr>\r\n                            <td");
            BeginWriteAttribute("id", " id=\"", 952, "\"", 999, 1);
            WriteAttributeValue("", 957, 
#nullable restore
#line 29 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                      $"login-provider-{login.LoginProvider}"

#line default
#line hidden
#nullable disable
            , 957, 42, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"fas fa-sign-in-alt\"></i> ");
            Write(
#nullable restore
#line 30 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                                                    login.ProviderDisplayName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 33 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                 if (Model.ShowRemoveButton)
                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b407713048", async() => {
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b407713371", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 36 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                                         login.LoginProvider

#line default
#line hidden
#nullable disable
                );
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b407715462", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => 
#nullable restore
#line 37 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                                         login.ProviderKey

#line default
#line hidden
#nullable disable
                );
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        <button type=""submit"" class=""btn btn-danger btn-sm"">
                                            <i class=""fas fa-trash-alt""></i> Xóa
                                        </button>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1310, 
#nullable restore
#line 35 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                                $"remove-login-{login.LoginProvider}"

#line default
#line hidden
#nullable disable
            , 1310, 40, false);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 42 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                                    <span class=\"text-muted\">Không thể xóa</span>\r\n");
#nullable restore
#line 46 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                }

#line default
#line hidden
#nullable disable

            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 49 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                    }

#line default
#line hidden
#nullable disable

            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 52 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
         if (Model.OtherLogins?.Count > 0)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <h4 class=\"mt-4\">Thêm phương thức đăng nhập khác</h4>\r\n            <hr />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b407721440", async() => {
                WriteLiteral("\r\n                <div class=\"d-flex flex-wrap gap-2\">\r\n");
#nullable restore
#line 60 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                     foreach (var provider in Model.OtherLogins)
                    {

#line default
#line hidden
#nullable disable

                WriteLiteral("                        <button");
                BeginWriteAttribute("id", " id=\"", 2694, "\"", 2738, 1);
                WriteAttributeValue("", 2699, 
#nullable restore
#line 62 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                      $"link-login-button-{provider.Name}"

#line default
#line hidden
#nullable disable
                , 2699, 39, false);
                EndWriteAttribute();
                WriteLiteral(" type=\"submit\" class=\"btn btn-outline-primary\">\r\n                            <i class=\"fas fa-plus\"></i> ");
                Write(
#nullable restore
#line 63 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                                                         provider.DisplayName

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </button>\r\n");
#nullable restore
#line 65 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
                    }

#line default
#line hidden
#nullable disable

                WriteLiteral("                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 68 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\Manage\ExternalLogins.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d2722cac98eef52dfa7f0009f80c5b05725d1111ae0c909cb46fbc7057b407725193", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExternalLoginsModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExternalLoginsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExternalLoginsModel>)PageContext?.ViewData;
        public ExternalLoginsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
