#pragma checksum "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Account\DeleteUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae0444f718219cb5505320e2b07dfb8a0f631a03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_DeleteUser), @"mvc.1.0.view", @"/Views/Account/DeleteUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/DeleteUser.cshtml", typeof(AspNetCore.Views_Account_DeleteUser))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog;

#line default
#line hidden
#line 2 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog.Models;

#line default
#line hidden
#line 3 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog.Models.AccountViewModels;

#line default
#line hidden
#line 4 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog.Models.ManageViewModels;

#line default
#line hidden
#line 5 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae0444f718219cb5505320e2b07dfb8a0f631a03", @"/Views/Account/DeleteUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3dc52dd6ef24831647a2e962b8124eb5102c62", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_DeleteUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 26, true);
            WriteLiteral("<div id=\"radniNalog2\">\r\n\r\n");
            EndContext();
            BeginContext(54, 95, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n\r\n        <div class=\"text-center\">\r\n\r\n");
            EndContext();
#line 13 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Account\DeleteUser.cshtml"
             if (ViewBag.nematePravo)
            {

#line default
#line hidden
            BeginContext(203, 63, true);
            WriteLiteral("                      <h4>Nemate Pravo brisati korisnike</h4>\r\n");
            EndContext();
#line 16 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Account\DeleteUser.cshtml"

            }
            else
            {

#line default
#line hidden
            BeginContext(316, 57, true);
            WriteLiteral("                    <h4>Uspjesno izbrisan korisnik</h4>\r\n");
            EndContext();
#line 21 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Account\DeleteUser.cshtml"
            }

#line default
#line hidden
            BeginContext(388, 188, true);
            WriteLiteral("\r\n            <a class=\"btn btn-danger btn-block\" href=\"http://localhost:3003/Home/Administracija#/useri/\">Povratak na Listu Korisnika</a>\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration TelemetryConfiguration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591