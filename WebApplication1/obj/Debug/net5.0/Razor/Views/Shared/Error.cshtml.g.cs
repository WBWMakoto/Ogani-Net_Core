#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\Shared\Error.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2cc6c5f43fa7b9c8740f2fc364f6bbba7bd7abe864fffefbfcc540ad04a8ce3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 2 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Areas.Identity

#nullable disable
    ;
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1

#nullable disable
    ;
#nullable restore
#line 4 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models

#nullable disable
    ;
#nullable restore
#line 5 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2cc6c5f43fa7b9c8740f2fc364f6bbba7bd7abe864fffefbfcc540ad04a8ce3c", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"e24b26f5154d8c3daf0560c7d010c33bbb71f2270fe3d5897e3257658a5b766a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Lỗi";

#line default
#line hidden
#nullable disable

            WriteLiteral(@"
<div class=""container text-center mt-5"">
    <h1 class=""text-danger""><i class=""fas fa-exclamation-circle""></i> Lỗi</h1>
    <h2 class=""text-danger"">Đã xảy ra lỗi trong quá trình xử lý yêu cầu.</h2>

    <h3 class=""mt-4"">Chế độ phát triển</h3>
    <p>
        Chuyển sang môi trường <strong>Phát triển</strong> sẽ hiển thị thông tin chi tiết hơn về lỗi đã xảy ra.
    </p>
    <p>
        <strong>Không nên bật chế độ phát triển trong môi trường triển khai thực tế</strong>
        vì có thể làm lộ thông tin nhạy cảm.
        Để bật chế độ phát triển khi chạy cục bộ, hãy đặt biến môi trường
        <strong>ASPNETCORE_ENVIRONMENT</strong> thành <strong>Development</strong> và khởi động lại ứng dụng.
    </p>
</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public 
#nullable restore
#line 7 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
WebApplication1.Data.ManageAppDbContext

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 7 "D:\Desktop\Ogani-Net_Core\WebApplication1\Views\_ViewImports.cshtml"
_context

#line default
#line hidden
#nullable disable
         { get; private set; }
         = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
