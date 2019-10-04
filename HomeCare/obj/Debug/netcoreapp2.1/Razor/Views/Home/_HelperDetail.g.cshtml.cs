#pragma checksum "D:\C#\HomeCare\HomeCare\Views\Home\_HelperDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b8cc2a31f3faf50ffa1526420d3356e0fca80cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__HelperDetail), @"mvc.1.0.view", @"/Views/Home/_HelperDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_HelperDetail.cshtml", typeof(AspNetCore.Views_Home__HelperDetail))]
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
#line 1 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using HomeCare;

#line default
#line hidden
#line 2 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using HomeCare.Models;

#line default
#line hidden
#line 3 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 4 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using HomeCare.Application.Common;

#line default
#line hidden
#line 5 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using HomeCare.Application.Common.Customer;

#line default
#line hidden
#line 6 "D:\C#\HomeCare\HomeCare\Views\_ViewImports.cshtml"
using HomeCare.Utilities.Constants;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b8cc2a31f3faf50ffa1526420d3356e0fca80cd", @"/Views/Home/_HelperDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35a610468b56632d64e8e9d799f05e86cc0eecb9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__HelperDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formhelperdetail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 544, true);
            WriteLiteral(@"<div id=""modalHelperDetail"" class=""modal fade"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" id=""btnHDClose"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"">Helper Detail</h4>
            </div>
            <div class=""modal-body"">
                <div id=""helperdetail-form"">
                    ");
            EndContext();
            BeginContext(544, 3617, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a827c4edc39a4a41b4581c987de20e14", async() => {
                BeginContext(608, 2201, true);
                WriteLiteral(@"
                        <div class=""form-group"">
                            <input type=""hidden"" id=""HeId""/>
                            <label for=""txtHDFullName"" class=""col-sm-3 control-label no-padding-right"">FullName</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtHDFullName"" class=""form-control"" id=""txtHDFullName"" placeholder=""FullName"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtHDEmail"" class=""col-sm-3 control-label no-padding-right"">Email</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" id=""txtHDEmail"" class=""form-control"" name=""txtHDEmail"" placeholder=""Email"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtHDPhoneNumber"" class=""col-");
                WriteLiteral(@"sm-3 control-label no-padding-right"">PhoneNumber</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtHDPhoneNumber"" class=""form-control"" id=""txtHDPhoneNumber"" placeholder=""PhoneNumber"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtHDBirthDay"" class=""col-sm-3 control-label no-padding-right"">BirthDay</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtHDBirthDay"" class=""form-control"" id=""txtHDBirthDay"" placeholder=""BirthDay"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtHDAddress"" class=""col-sm-3 control-label no-padding-right"">Address</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" ");
                WriteLiteral("name=\"txtHDAddress\" class=\"form-control\" id=\"txtHDAddress\" placeholder=\"Address\">\r\n                            </div>\r\n                        </div>\r\n\r\n");
                EndContext();
                BeginContext(3281, 121, true);
                WriteLiteral("\r\n                        <div class=\"form-group\">\r\n                            <div class=\"col-sm-offset-2 col-sm-10\">\r\n");
                EndContext();
                BeginContext(4064, 90, true);
                WriteLiteral("                            </div>\r\n                        </div>\r\n\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
            BeginContext(4161, 202, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" id=\"btnHDCancel\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>\r\n");
            EndContext();
            BeginContext(4465, 117, true);
            WriteLiteral("            </div>\r\n        </div><!-- /.modal-content -->\r\n    </div><!-- /.modal-dialog -->\r\n</div><!-- /.modal -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591