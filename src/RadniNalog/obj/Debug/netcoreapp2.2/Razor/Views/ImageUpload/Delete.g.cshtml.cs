#pragma checksum "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bca3993ed2e708b84ae7b5075ec6fc2e032c5d02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageUpload_Delete), @"mvc.1.0.view", @"/Views/ImageUpload/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageUpload/Delete.cshtml", typeof(AspNetCore.Views_ImageUpload_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bca3993ed2e708b84ae7b5075ec6fc2e032c5d02", @"/Views/ImageUpload/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3dc52dd6ef24831647a2e962b8124eb5102c62", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageUpload_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 108, true);
            WriteLiteral("<div class=\"container fixmarg\">\r\n\r\n\r\n    <h3 class=\"text-center\">Uspjesno ste izbrisali fotografiju</h3>\r\n\r\n");
            EndContext();
            BeginContext(199, 8, true);
            WriteLiteral("\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 207, "\"", 248, 2);
            WriteAttributeValue("", 214, "/ImageUpload/Details/", 214, 21, true);
#line 8 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Delete.cshtml"
WriteAttributeValue("", 235, ViewBag.myid, 235, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(249, 69, true);
            WriteLiteral(" class=\"btn btn-block btn-danger\">Povratak u galeriju</a>\r\n\r\n</div>\r\n");
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