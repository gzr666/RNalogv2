#pragma checksum "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ebeed89b0e6ddee82a5a9caad83c376155c7370"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageUpload_Index), @"mvc.1.0.view", @"/Views/ImageUpload/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageUpload/Index.cshtml", typeof(AspNetCore.Views_ImageUpload_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ebeed89b0e6ddee82a5a9caad83c376155c7370", @"/Views/ImageUpload/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3dc52dd6ef24831647a2e962b8124eb5102c62", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageUpload_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<string>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/mygallery.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml"
  

    Layout = null;



#line default
#line hidden
            BeginContext(61, 563, true);
            WriteLiteral(@"
<link href=""//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
<script src=""//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js""></script>
<script src=""//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
<!------ Include the above in your HEAD tag ---------->
<link rel=""stylesheet"" href=""//cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css"" media=""screen"">
<script src=""//cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js""></script>

");
            EndContext();
            BeginContext(624, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5ebeed89b0e6ddee82a5a9caad83c376155c73705153", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(674, 101, true);
            WriteLiteral("\r\n<!-- Page Content -->\r\n<div class=\"container page-top\">\r\n\r\n\r\n   \r\n\r\n    <div class=\"row\">\r\n\r\n\r\n\r\n\r\n");
            EndContext();
#line 28 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml"
         foreach (var img in Model)
    {


#line default
#line hidden
            BeginContext(821, 70, true);
            WriteLiteral("        <div class=\"col-lg-3 col-md-4 col-xs-6 thumb\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 891, "\"", 902, 1);
#line 32 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml"
WriteAttributeValue("", 898, img, 898, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(903, 55, true);
            WriteLiteral(" class=\"fancybox\" rel=\"ligthbox\">\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 958, "\"", 968, 1);
#line 33 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml"
WriteAttributeValue("", 964, img, 964, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(969, 74, true);
            WriteLiteral(" class=\"zoom img-fluid \" alt=\"test\">\r\n\r\n            </a>\r\n        </div>\r\n");
            EndContext();
#line 37 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\ImageUpload\Index.cshtml"




}

#line default
#line hidden
            BeginContext(1054, 500, true);
            WriteLiteral(@"








    </div>


</div>

<div class=""container"">


    <a href=""/"" class=""btn btn-block btn-danger"">Povratak</a>

</div>


<script>

    $(document).ready(function () {
        $("".fancybox"").fancybox({
            openEffect: ""none"",
            closeEffect: ""none""
        });

        $("".zoom"").hover(function () {

            $(this).addClass('transition');
        }, function () {

            $(this).removeClass('transition');
        });
    });


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
