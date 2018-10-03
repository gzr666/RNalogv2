#pragma checksum "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61983d06b8ecf38ab2a7fe9a37ae98fe2aef2b87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_home), @"mvc.1.0.view", @"/Views/Home/home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/home.cshtml", typeof(AspNetCore.Views_Home_home))]
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
#line 3 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog.Models.AccountViewModels;

#line default
#line hidden
#line 4 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\_ViewImports.cshtml"
using RadniNalog.Models.ManageViewModels;

#line default
#line hidden
#line 2 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
using RadniNalog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61983d06b8ecf38ab2a7fe9a37ae98fe2aef2b87", @"/Views/Home/home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3dc52dd6ef24831647a2e962b8124eb5102c62", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(66, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(174, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 11 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
  
    Layout = null;

   

#line default
#line hidden
            BeginContext(214, 200, true);
            WriteLiteral("\r\n\r\n       \r\n        <div class=\"panel panel-primary snizi\" id=\"radniNalog\">\r\n            <div class=\"panel-heading text-center\"><h3>Radni Nalozi</h3></div>\r\n            <div class=\"panel-body\">\r\n\r\n\r\n");
            EndContext();
#line 24 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
                 if (User.IsInRole("SuperAdmin") || User.IsInRole("Admin") || User.IsInRole("Korisnik"))
                {


#line default
#line hidden
            BeginContext(541, 104, true);
            WriteLiteral("                     <a class=\"btn btn-danger btn-block btn-lg\" ng-click=\"gotoprint()\">Dodaj Nalog</a>\r\n");
            EndContext();
#line 28 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
                }

#line default
#line hidden
            BeginContext(664, 1732, true);
            WriteLiteral(@"
                <table ng-table=""usersTable"" show-filter=""true"" class=""table table-striped table-condensed table-bordered "">

                    <tr ng-repeat=""user in data"">
                       
                        <td data-title=""'Datum'"" sortable=""'datum'"" filter=""{ 'datum': 'text' }"">
                            {{user.datum | date: 'dd-MM-yyyy' }}
                        </td>
                        <td data-title=""'Rukovoditelj'"" sortable=""'rukovoditelj'"" filter=""{ 'rukovoditelj': 'text' }"">
                            {{user.rukovoditelj | limitTo: 20 }}
                        </td>
                        <td data-title=""'Izvrsitelj2'"" sortable=""'izvrsitelj2'"" filter=""{ 'izvrsitelj2': 'text' }"">
                            {{user.izvrsitelj2 ? user.izvrsitelj2 : ""-""}}
                        </td>
                        <td data-title=""'Izvrsitelj3'"" sortable=""'izvrsitelj3'"" filter=""{ 'izvrsitelj3': 'text' }"">
                            {{user.izvrsitelj3 ? user.izvrsitelj3");
            WriteLiteral(@" : ""-""}}
                        </td>
                        <td data-title=""'Mjesto Rada'"" sortable=""'mjestoRada'"" filter=""{ 'mjestoRada': 'text' }"">
                            {{user.mjestoRada}}
                        </td>

                        <td data-title=""'Automobil'"" sortable=""'automobil'"" filter=""{ 'automobil': 'text' }"">
                            {{user.automobil}}
                        </td>

                        <td data-title=""'Opis Radova'"" sortable=""'opisRadova'"" filter=""{ 'opisRadova': 'text' }"">
                            {{user.opisRadova}}
                        </td>

                        
                        

                       

");
            EndContext();
#line 63 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
                         if (User.IsInRole("SuperAdmin") || User.IsInRole("Admin") )
                        {

                        

#line default
#line hidden
            BeginContext(2537, 51, true);
            WriteLiteral("                        <td data-title=\"\'Uredi\'\">\r\n");
            EndContext();
            BeginContext(2706, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2825, 495, true);
            WriteLiteral(@"
                            <a class=""btn btn-primary btn-sm"" ng-click=""gotoEditNalog(user)"">Uredi Nalog</a>




                        </td>
                        <td data-title=""'Brisanje'"">

                           
                                            <button class=""btn btn-danger btn-block"" ng-click=""removeNalog(user)"" id=""modalTesters"">Izbriši</button>
                                       



                           

                        </td>
");
            EndContext();
            BeginContext(3322, 290, true);
            WriteLiteral(@"                        <td data-title=""'Printaj Nalog'"">
                            <a href=""/api/pdf/kreirajPDF/{{user.id}}"" class=""btn btn-danger btn-sm"" target=""_blank""><span class=""glyphicon glyphicon-print""></span><span> Isprintaj Nalog</span></a>

                        </td>
");
            EndContext();
#line 94 "E:\Projects\RNALOGV3_git\RNalogv2\src\RadniNalog\Views\Home\home.cshtml"
                        }

#line default
#line hidden
            BeginContext(3639, 586, true);
            WriteLiteral(@"                    </tr>
                </table>

                

                <div class=""btn-group btn-group-justified"">
                    <a href=""/api/pdf/listaNaloga"" class=""btn btn-primary btn-block btn-lg""><span class=""glyphicon glyphicon-print""></span><span> Printaj Sve Naloge-PDF</span></a>
                    <a href=""/api/pdf"" class=""btn btn-primary btn-block btn-lg""><span class=""glyphicon glyphicon-new-window""></span><span> Excel Export</span></a>
                    
                </div> 

                
            </div>

        </div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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