#pragma checksum "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\Bill\_HelperDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb05fc44a3d08307ca37765f12796de68b659048"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Bill__HelperDetail), @"mvc.1.0.view", @"/Areas/Admin/Views/Bill/_HelperDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Bill/_HelperDetail.cshtml", typeof(AspNetCore.Areas_Admin_Views_Bill__HelperDetail))]
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
#line 1 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare;

#line default
#line hidden
#line 2 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare.Models;

#line default
#line hidden
#line 3 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 4 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare.Application.ViewModels.Admin;

#line default
#line hidden
#line 5 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare.Application.Common;

#line default
#line hidden
#line 6 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare.Application.Common.Admin;

#line default
#line hidden
#line 7 "D:\C#\HomeCare\HomeCare\Areas\Admin\Views\_ViewImports.cshtml"
using HomeCare.Utilities.Constants;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb05fc44a3d08307ca37765f12796de68b659048", @"/Areas/Admin/Views/Bill/_HelperDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d829a3d2ae558687171138e8d6512126770ca7b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Bill__HelperDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmHelperDetail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 546, true);
            WriteLiteral(@"<div id=""modalHelperDetail"" class=""modal fade"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" id=""btnHeDiClose"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"">Helper Detail</h4>
            </div>
            <div class=""modal-body"">
                <div id=""helperdetail-form"">
                    ");
            EndContext();
            BeginContext(546, 5626, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "438db680a4d54299b9263ea89a1b6a39", async() => {
                BeginContext(609, 4821, true);
                WriteLiteral(@"
                        <div class=""form-group"">
                            <input type=""hidden"" id=""HeId"" value=""0"" />
                            <label for=""txtUserName"" class=""col-sm-3 control-label no-padding-right"">UserName</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtUserName"" class=""form-control"" id=""txtUserName"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtFullName"" class=""col-sm-3 control-label no-padding-right"">FullName</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" id=""txtFullName"" class=""form-control"" name=""txtFullName"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtEmail"" class=""col-sm-3 control-label no-padding-right"">Ema");
                WriteLiteral(@"il</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtEmail"" class=""form-control"" id=""txtEmail"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtPhoneNumber"" class=""col-sm-3 control-label no-padding-right"">PhoneNumber</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtPhoneNumber"" class=""form-control"" id=""txtPhoneNumber"">
                            </div>
                        </div>

                        <div class=""form-group"">
                            <label for=""txtIDcard"" class=""col-sm-3 control-label no-padding-right"">IDcard</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtIDcard"" class=""form-control"" id=""txtIDcard"">
                            </div>
                ");
                WriteLiteral(@"        </div>
                        <div class=""form-group"">
                            <label for=""txtBirthDay"" class=""col-sm-3 control-label no-padding-right"">BirthDay</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtBirthDay"" class=""form-control"" id=""txtBirthDay"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtAddress"" class=""col-sm-3 control-label no-padding-right"">Address</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtAddress"" class=""form-control"" id=""txtAddress"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtCancelBillNumber"" class=""col-sm-3 control-label no-padding-right"">CancelBillNumber</label>
                            <");
                WriteLiteral(@"div class=""col-sm-9"">
                                <input type=""number"" name=""txtCancelBillNumber"" class=""form-control"" id=""txtCancelBillNumber"">
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""txtPaymoney"" class=""col-sm-3 control-label no-padding-right"">Paymoney</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtPaymoney"" class=""form-control"" id=""txtPaymoney"">
                            </div>
                        </div>

                        <div class=""form-group"">
                            <label for=""txtDateCreated"" class=""col-sm-3 control-label no-padding-right"">CreateDate</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtDateCreated"" class=""form-control"" id=""txtDateCreated"">
                            </div>
                        </");
                WriteLiteral(@"div>

                        <div class=""form-group"">
                            <label for=""txtDateModified"" class=""col-sm-3 control-label no-padding-right"">ModifyDate</label>
                            <div class=""col-sm-9"">
                                <input type=""text"" name=""txtDateModified"" class=""form-control"" id=""txtDateModified"">
                            </div>
                        </div>

                        <div class=""form-group"">
                            <label for=""txtStatus"" class=""col-sm-3 control-label no-padding-right"">Status</label>
                            <div class=""col-sm-9"" id=""txtStatus"">
                            </div>
                        </div>

");
                EndContext();
                BeginContext(6143, 22, true);
                WriteLiteral("\r\n                    ");
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
            BeginContext(6172, 501, true);
            WriteLiteral(@"
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" id=""btnHeDiCancel"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


<!-- Bill Status -->
<script id=""table-template-helperstatus"" type=""x-tmpl-mustache"">
    <p style=""margin-bottom: unset; margin-top: 7px"">{{{helperstatus}}}</p>
</script>");
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
