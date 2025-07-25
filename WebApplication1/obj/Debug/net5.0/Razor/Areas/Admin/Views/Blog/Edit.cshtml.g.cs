#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "624ea71da89c1498053c61e1843f57a49a33174c4c9325c1d3dd069d604e1763"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/Edit.cshtml")]
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
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"624ea71da89c1498053c61e1843f57a49a33174c4c9325c1d3dd069d604e1763", @"/Areas/Admin/Views/Blog/Edit.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Blog_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.BlogViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h2 class=\"text-center mt-4\">Chỉnh sửa bài viết</h2>\r\n\r\n<div class=\"card shadow-sm p-4\">\r\n    <form asp-area=\"Admin\" asp-controller=\"Blog\" asp-action=\"Edit\" method=\"post\">\r\n        ");
            Write(
#nullable restore
#line 11 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
         Html.AntiForgeryToken()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"
        <input type=""hidden"" asp-for=""Id"" />
        <input type=""hidden"" asp-for=""CreatedDate"" />

        <div class=""form-group"">
            <label asp-for=""Title"" class=""font-weight-bold"">Tiêu đề</label>
            <input asp-for=""Title"" class=""form-control"" name=""Title""");
            BeginWriteAttribute("value", " value=\"", 609, "\"", 629, 1);
            WriteAttributeValue("", 617, 
#nullable restore
#line 17 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                                                                             Model.Title

#line default
#line hidden
#nullable disable
            , 617, 12, false);
            EndWriteAttribute();
            WriteLiteral(@" required placeholder=""Nhập tiêu đề bài viết..."" />
            <span asp-validation-for=""Title"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""Content"" class=""font-weight-bold"">Nội dung</label>
            <textarea asp-for=""Content"" class=""form-control"" name=""Content"" rows=""5"" placeholder=""Nhập nội dung bài viết..."">");
            Write(
#nullable restore
#line 23 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                                                                                                                              Model.Content

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"</textarea>
            <span asp-validation-for=""Content"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""ImageUrl"" class=""font-weight-bold"">Hình ảnh</label>
            <input asp-for=""ImageUrl"" class=""form-control"" name=""ImageUrl""");
            BeginWriteAttribute("value", " value=\"", 1324, "\"", 1347, 1);
            WriteAttributeValue("", 1332, 
#nullable restore
#line 29 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                                                                                   Model.ImageUrl

#line default
#line hidden
#nullable disable
            , 1332, 15, false);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Nhập URL hình ảnh...\" />\r\n            <span asp-validation-for=\"ImageUrl\" class=\"text-danger\"></span>\r\n");
#nullable restore
#line 31 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
             if (!string.IsNullOrEmpty(Model.ImageUrl))
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <div class=\"mt-2\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1597, "\"", 1618, 1);
            WriteAttributeValue("", 1603, 
#nullable restore
#line 34 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                               Model.ImageUrl

#line default
#line hidden
#nullable disable
            , 1603, 15, false);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1619, "\"", 1637, 1);
            WriteAttributeValue("", 1625, 
#nullable restore
#line 34 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                                                     Model.Title

#line default
#line hidden
#nullable disable
            , 1625, 12, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\" style=\"width: 150px; height: 150px;\" />\r\n                </div>\r\n");
#nullable restore
#line 36 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label asp-for=\"Author\" class=\"font-weight-bold\">Tác giả</label>\r\n            <input asp-for=\"Author\" class=\"form-control\" name=\"Author\"");
            BeginWriteAttribute("value", " value=\"", 1941, "\"", 1962, 1);
            WriteAttributeValue("", 1949, 
#nullable restore
#line 41 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\Edit.cshtml"
                                                                               Model.Author

#line default
#line hidden
#nullable disable
            , 1949, 13, false);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""Nhập tên tác giả..."" />
            <span asp-validation-for=""Author"" class=""text-danger""></span>
        </div>

        <div class=""text-center mt-3"">
            <button type=""submit"" class=""btn btn-success px-4"">Lưu thay đổi</button>
            <a asp-action=""Index"" class=""btn btn-secondary px-4 ml-2"">Quay lại</a>
        </div>
    </form>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <partial name=\"_ValidationScriptsPartial\" />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.BlogViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
