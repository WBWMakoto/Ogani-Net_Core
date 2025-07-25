#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\EditComment.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ca5b65958a109923dd72be5960b6cf661dd0769a5cc4b9b7a9039bba289b67b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_EditComment), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/EditComment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4ca5b65958a109923dd72be5960b6cf661dd0769a5cc4b9b7a9039bba289b67b", @"/Areas/Admin/Views/Blog/EditComment.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Blog_EditComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.Comment>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\EditComment.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h2 class=\"text-center mt-4\">Chỉnh sửa bình luận</h2>\r\n\r\n<div class=\"card shadow-sm p-4\">\r\n    <form asp-area=\"Admin\" asp-controller=\"Blog\" asp-action=\"EditComment\" method=\"post\">\r\n        ");
            Write(
#nullable restore
#line 11 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\EditComment.cshtml"
         Html.AntiForgeryToken()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"
        <input type=""hidden"" asp-for=""Id"" />
        <input type=""hidden"" asp-for=""BlogPostId"" />
        <input type=""hidden"" asp-for=""CreatedDate"" />

        <div class=""form-group"">
            <label asp-for=""Content"" class=""font-weight-bold"">Nội dung</label>
            <textarea asp-for=""Content"" class=""form-control"" name=""Content"" rows=""3"" required placeholder=""Nhập nội dung bình luận...""></textarea>
            <span asp-validation-for=""Content"" class=""text-danger""></span>
        </div>

        <div class=""form-group"">
            <label asp-for=""UserId"" class=""font-weight-bold"">Người dùng</label>
            <input asp-for=""UserId"" class=""form-control"" name=""UserId"" readonly />
            <span asp-validation-for=""UserId"" class=""text-danger""></span>
        </div>

        <div class=""text-center mt-3"">
            <button type=""submit"" class=""btn btn-success px-4"">Lưu thay đổi</button>
            <a asp-action=""Details""");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1295, "\"", 1327, 1);
            WriteAttributeValue("", 1310, 
#nullable restore
#line 30 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Admin\Views\Blog\EditComment.cshtml"
                                                   Model.BlogPostId

#line default
#line hidden
#nullable disable
            , 1310, 17, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary px-4 ml-2\">Quay lại</a>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.Comment> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
