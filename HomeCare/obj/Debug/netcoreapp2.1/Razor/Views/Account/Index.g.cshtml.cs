#pragma checksum "D:\C#\HomeCare\HomeCare\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72ecf61e8325d68e8d2a523833153e3360ae72b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Index.cshtml", typeof(AspNetCore.Views_Account_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72ecf61e8325d68e8d2a523833153e3360ae72b1", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35a610468b56632d64e8e9d799f05e86cc0eecb9", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customer-side/controller/register/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmLogin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\C#\HomeCare\HomeCare\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(64, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(91, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(97, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e195ef6abee4382982db8f08c0486ca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(165, 71, true);
                WriteLiteral("\r\n    <script>\r\n        registerController.register();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(239, 384, true);
            WriteLiteral(@"


<!-- Main Container -->
<section class=""main-container col1-layout"">
    <div class=""main container"">
        <div class=""page-content"">
            <div class=""account-login"">
                <div class=""col-md-3 col-sm-2""></div>
                <div class=""col-md-6 col-sm-8"">
                    <div class=""single-input p-bottom50 clearfix"">
                        ");
            EndContext();
            BeginContext(623, 4648, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1733d2ebfbe4b6bbf648ddf1f6275b9", async() => {
                BeginContext(643, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(674, 23, false);
#line 29 "D:\C#\HomeCare\HomeCare\Views\Account\Index.cshtml"
                       Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(697, 4567, true);
                WriteLiteral(@"
                            <div class=""row"">
                                <div class=""col-xs-12"">
                                    <div class=""check-title"">
                                        <h2>New Customer</h2>
                                    </div>
                                </div>
                                <div class=""col-sm-6"" style=""margin-bottom: 15px"">
                                    <label>UserName:</label>
                                    <div class=""input-text"">
                                        <input id=""txtUserName"" type=""text"" name=""txtUserName"" placeholder=""Username"" class=""form-control"" required="""">
                                    </div>
                                </div>
                                <div class=""col-sm-6"" style=""margin-bottom: 15px"">
                                    <label>FullName:</label>
                                    <div class=""input-text"">
                                        <input id=""txtF");
                WriteLiteral(@"ullName"" type=""text"" name=""txtFullName"" placeholder=""Fullname"" class=""form-control"" required="""">
                                    </div>
                                </div>
                                <div class=""col-xs-12"" style=""margin-bottom: 15px"">
                                    <label>Password:</label>
                                    <div class=""input-text"">
                                        <input id=""txtPassword"" type=""password"" name=""txtPassword"" placeholder=""Password"" class=""form-control"" required="""">
                                    </div>
                                </div>
                                <div class=""col-xs-12"" style=""margin-bottom: 15px"">
                                    <label>PasswordComfirm:</label>
                                    <div class=""input-text"">
                                        <input id=""txtPasswordComfirm"" type=""password"" name=""txtPasswordComfirm"" placeholder=""Passwordcomfirm"" class=""form-control"" required="""">");
                WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""col-sm-6"" style=""margin-bottom: 15px"">
                                    <label>Email:</label>
                                    <div class=""input-text"">
                                        <input id=""txtEmail"" type=""email"" name=""txtEmail"" placeholder=""email"" class=""form-control"" required="""">
                                    </div>
                                </div>
                                <div class=""col-sm-6"" style=""margin-bottom: 15px"">
                                    <label>PhoneNumber:</label>
                                    <div class=""input-text"">
                                        <input id=""txtPhoneNumber"" type=""text"" name=""txtPhoneNumber"" placeholder=""phonenumber"" class=""form-control"" required="""">
                                    </div>
                                </div>
                                <div class=""col");
                WriteLiteral(@"-xs-12"" style=""margin-bottom: 15px"">
                                    <label>Address:</label>
                                    <div class=""input-text"">
                                        <input id=""txtAddress"" type=""text"" name=""txtAddress"" placeholder=""address"" class=""form-control"" required="""">
                                    </div>
                                </div>

                                <div class=""col-xs-6"" style=""margin-top: 25px"">
                                    <div>
                                    </div>
                                    <div class=""submit-text"">
                                        <button id=""btnRegister"" class=""button""><i class=""fa fa-user""></i>&nbsp; <span>Register</span></button>
                                    </div>
                                </div>
                                <div class=""col-xs-6"" style=""padding-left: 119px"">
                                    <div style=""margin-bottom: 7px"">
             ");
                WriteLiteral(@"                           Already have an account!
                                    </div>
                                    <div class=""submit-text"">
                                        <button id=""btnLogin"" style=""margin-left: 29px"" class=""button""><i class=""fa fa-user""></i>&nbsp; <span>Login</span></button>
                                    </div>
                                </div>

                            </div>
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5271, 616, true);
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
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
</div>");
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
