#pragma checksum "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cd0f3c746eb8442caea8ca67818c560a9094608"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Helper_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Helper/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Helper/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Helper_Views_Home_Index))]
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
#line 1 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using HomeCare;

#line default
#line hidden
#line 2 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using HomeCare.Models;

#line default
#line hidden
#line 3 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 4 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using HomeCare.Application.Common;

#line default
#line hidden
#line 5 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using HomeCare.Application.Common.Helper;

#line default
#line hidden
#line 6 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\_ViewImports.cshtml"
using HomeCare.Utilities.Constants;

#line default
#line hidden
#line 1 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
using HomeCare.Data.Enums;

#line default
#line hidden
#line 2 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
using HomeCare.Application.ViewModels.Helper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cd0f3c746eb8442caea8ca67818c560a9094608", @"/Areas/Helper/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fce9b802abb29559c5144f9634e0ca91f640098", @"/Areas/Helper/Views/_ViewImports.cshtml")]
    public class Areas_Helper_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeCare.Utilities.Dtos.PagedResult<HelperBillViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/helper-side/controller/home/index.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customer-side/template/images/blog-img1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Blog"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(140, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(187, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(208, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(215, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(235, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(241, 88, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58ef797580cd4ecb9452b50562dc89c6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 15 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(329, 78, true);
                WriteLiteral("\r\n    <script>\r\n        registerEvents();\r\n        hpcheck();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(410, 805, true);
            WriteLiteral(@"

<!-- Main Container -->

<section class=""blog_post"">
    <div class=""container"">

        <!-- row -->
        <div class=""row"">

            <!-- Center colunm-->
            <div class=""center_column col-xs-12 col-sm-12"" id=""center_column"">
                <div class=""page-title"">
                    <div class=""row"">
                        <div class=""col-sm-9"">
                            <h2>Bill List</h2>
                        </div>
                        <div class=""col-sm-3"">
                            <button id=""btnReload"" class=""btn btn-primary btn-dm""><i class=""fa fa-refresh"" style=""margin-right: 5px""></i> Reload BillStatus</button>
                        </div>
                    </div>
                </div>
                <ul class=""blog-posts"">
");
            EndContext();
#line 44 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                     if (Model.Results != null)
                    {
                        

#line default
#line hidden
#line 46 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                         foreach (var item in Model.Results)
                        {

#line default
#line hidden
            BeginContext(1376, 381, true);
            WriteLiteral(@"                            <li class=""post-item wow fadeInUp"">
                                <article class=""entry"">
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <div class=""entry-thumb image-hover2"">
                                                <figure>");
            EndContext();
            BeginContext(1757, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "afeabf8b10004be985df21bcba69ef2f", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1825, 271, true);
            WriteLiteral(@"</figure>
                                            </div>
                                        </div>
                                        <div class=""col-sm-8"">
                                            <h4 class=""entry-title"" style=""margin-bottom: 10px"">");
            EndContext();
            BeginContext(2097, 14, false);
#line 57 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                           Write(item.Workplace);

#line default
#line hidden
            EndContext();
            BeginContext(2111, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(2114, 20, false);
#line 57 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                            Write(item.Apartmentnumber);

#line default
#line hidden
            EndContext();
            BeginContext(2134, 168, true);
            WriteLiteral("</h4>\r\n                                            <div class=\"entry-meta-data\" style=\"margin-bottom: 10px\"> <span class=\"author\"> <i class=\"pe-7s-user\"></i>&nbsp; by: ");
            EndContext();
            BeginContext(2303, 17, false);
#line 58 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                                                                            Write(item.CustomerName);

#line default
#line hidden
            EndContext();
            BeginContext(2320, 78, true);
            WriteLiteral("</span> <span class=\"cat\"> <i class=\"pe-7s-folder\"></i>&nbsp; Starting Time : ");
            EndContext();
            BeginContext(2399, 14, false);
#line 58 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                            Write(item.Starttime);

#line default
#line hidden
            EndContext();
            BeginContext(2413, 74, true);
            WriteLiteral(" </span> <span class=\"comment-count\"> <i class=\"pe-7s-comment\"></i>&nbsp; ");
            EndContext();
            BeginContext(2488, 17, false);
#line 58 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                     Write(item.Workinghours);

#line default
#line hidden
            EndContext();
            BeginContext(2505, 61, true);
            WriteLiteral(" </span> <span class=\"date\"><i class=\"pe-7s-date\"></i>&nbsp; ");
            EndContext();
            BeginContext(2567, 12, false);
#line 58 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                    Write(item.Workday);

#line default
#line hidden
            EndContext();
            BeginContext(2579, 196, true);
            WriteLiteral("</span> </div>\r\n                                            <div class=\"rating\" style=\"margin-bottom: 10px\">\r\n                                                <h4><span class=\"label label-primary\">");
            EndContext();
            BeginContext(2776, 15, false);
#line 60 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                 Write(item.BillStatus);

#line default
#line hidden
            EndContext();
            BeginContext(2791, 145, true);
            WriteLiteral("</span></h4>\r\n                                            </div>\r\n                                            <div class=\"entry-excerpt\"><strong>");
            EndContext();
            BeginContext(2937, 16, false);
#line 62 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                          Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(2953, 196, true);
            WriteLiteral("</strong></div>\r\n                                            <div class=\"entry-more\">\r\n                                                <button class=\"btn btn-info btn-md btn-detail-bill\" data-id=\"");
            EndContext();
            BeginContext(3150, 7, false);
#line 64 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                                                                                                        Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3157, 269, true);
            WriteLiteral(@"""><i class=""fa fa-info-circle""></i></button>
                                            </div>
                                        </div>
                                    </div>
                                </article>
                            </li>
");
            EndContext();
#line 70 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#line 70 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(3476, 39, true);
            WriteLiteral("                </ul>\r\n                ");
            EndContext();
            BeginContext(3517, 49, false);
#line 73 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
            Write(await Component.InvokeAsync("HelperPager", Model));

#line default
#line hidden
            EndContext();
            BeginContext(3567, 645, true);
            WriteLiteral(@"
            </div>
            <!-- ./ Center colunm -->
        </div>
        <!-- ./row-->
    </div>
</section>
<!-- Main Container End -->
<!-- service section -->
<div class=""jtv-service-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col col-md-3 col-sm-6 col-xs-12"">

            </div>
            <div class=""col col-md-3 col-sm-6 col-xs-12 "">

            </div>
            <div class=""col col-md-3 col-sm-6 col-xs-12"">

            </div>
            <div class=""col col-md-3 col-sm-6 col-xs-12"">

            </div>
        </div>               
    </div>
</div>

");
            EndContext();
            BeginContext(4213, 45, false);
#line 101 "D:\C#\HomeCare\HomeCare\Areas\Helper\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("_BillDetail.cshtml"));

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeCare.Utilities.Dtos.PagedResult<HelperBillViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
