#pragma checksum "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b3842d281295f89387bf7ee2a6215a26da1ebc293635db34993f63e46d606163"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_ForgotPasswordConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/ForgotPasswordConfirmation.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b3842d281295f89387bf7ee2a6215a26da1ebc293635db34993f63e46d606163", @"/Areas/Identity/Pages/Account/ForgotPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c048d9e345094ddb01ae01e669e7f66e497939e36a30b05fffced62c098288a5", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"329aeeaedfd2631b274bdab61781c87eafbc960a487846b5e8f774fadd95b5ef", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Pages_Account_ForgotPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml"
  
    ViewData["Title"] = "Xác nhận quên mật khẩu";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>");
            Write(
#nullable restore
#line 7 "D:\Desktop\Ogani-Net_Core\WebApplication1\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml"
     ViewData["Title"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h1>\r\n<p>\r\n    Vui lòng kiểm tra email của bạn để đặt lại mật khẩu.\r\n</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ForgotPasswordConfirmation> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ForgotPasswordConfirmation> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ForgotPasswordConfirmation>)PageContext?.ViewData;
        public ForgotPasswordConfirmation Model => ViewData.Model;
    }
}
#pragma warning restore 1591
