#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Error.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a0db6c23a2e99cd7c792a4fee1dcf46ccdced854f0cedbc786bafd104fb77e3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Error), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Error.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a0db6c23a2e99cd7c792a4fee1dcf46ccdced854f0cedbc786bafd104fb77e3e", @"/Areas/Identity/Pages/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c048d9e345094ddb01ae01e669e7f66e497939e36a30b05fffced62c098288a5", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Pages_Error : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Error.cshtml"
  
    ViewData["Title"] = "Lỗi";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container text-center mt-5\">\r\n    <h1 class=\"text-danger\"><i class=\"fas fa-exclamation-triangle\"></i> Lỗi</h1>\r\n    <h2 class=\"text-danger\">Đã xảy ra lỗi trong quá trình xử lý yêu cầu.</h2>\r\n\r\n");
#nullable restore
#line 11 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Error.cshtml"
     if (Model.ShowRequestId)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <p class=\"mt-3\">\r\n            <strong>ID yêu cầu:</strong> <code>");
            Write(
#nullable restore
#line 14 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Error.cshtml"
                                                Model.RequestId

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</code>\r\n        </p>\r\n");
#nullable restore
#line 16 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Error.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"
    <div class=""alert alert-warning mt-4"">
        <h4>Chế độ phát triển</h4>
        <p>
            Chuyển sang môi trường <strong>Phát triển</strong> sẽ hiển thị thông tin chi tiết hơn về lỗi đã xảy ra.
        </p>
        <p>
            <strong>Không nên bật chế độ phát triển trong môi trường triển khai thực tế</strong> vì có thể lộ thông tin nhạy cảm từ lỗi.
            Để bật chế độ phát triển khi chạy cục bộ, hãy đặt biến môi trường <strong>ASPNETCORE_ENVIRONMENT</strong> thành <strong>Development</strong> và khởi động lại ứng dụng.
        </p>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorModel>)PageContext?.ViewData;
        public ErrorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
