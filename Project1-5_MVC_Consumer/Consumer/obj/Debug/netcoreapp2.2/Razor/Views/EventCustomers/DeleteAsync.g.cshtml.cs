#pragma checksum "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef82c14694eb05d9c43bb05d82d6ffd732311040"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventCustomers_DeleteAsync), @"mvc.1.0.view", @"/Views/EventCustomers/DeleteAsync.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EventCustomers/DeleteAsync.cshtml", typeof(AspNetCore.Views_EventCustomers_DeleteAsync))]
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
#line 1 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\_ViewImports.cshtml"
using Consumer;

#line default
#line hidden
#line 2 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\_ViewImports.cshtml"
using Consumer.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef82c14694eb05d9c43bb05d82d6ffd732311040", @"/Views/EventCustomers/DeleteAsync.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7669a2734c33a8de67105ad519fa53565cc724", @"/Views/_ViewImports.cshtml")]
    public class Views_EventCustomers_DeleteAsync : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project1_5_Library.EventCustomer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAsync", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
  
    ViewData["Title"] = "DeleteAsync";

#line default
#line hidden
            BeginContext(90, 158, true);
            WriteLiteral("\r\n<h1>Delete this event from customer</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <dl class=\"row\">\r\n    <dt class=\"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(249, 38, false);
#line 13 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(287, 49, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(337, 34, false);
#line 16 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(371, 107, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        Customer\r\n\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(479, 45, false);
#line 23 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.Name));

#line default
#line hidden
            EndContext();
            BeginContext(524, 16, true);
            WriteLiteral("<br />\r\n        ");
            EndContext();
            BeginContext(541, 50, false);
#line 24 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(591, 18, true);
            WriteLiteral("<br />\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 609, "\"", 670, 2);
            WriteAttributeValue("", 616, "mailto:", 616, 7, true);
#line 25 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
WriteAttributeValue("", 623, Html.DisplayFor(model => model.Customer.Email), 623, 47, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(671, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(673, 46, false);
#line 25 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
                                                                    Write(Html.DisplayFor(model => model.Customer.Email));

#line default
#line hidden
            EndContext();
            BeginContext(719, 20, true);
            WriteLiteral("</a><br />\r\n        ");
            EndContext();
            BeginContext(740, 49, false);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.Address1));

#line default
#line hidden
            EndContext();
            BeginContext(789, 13, true);
            WriteLiteral(".\r\n\r\n        ");
            EndContext();
            BeginContext(803, 49, false);
#line 28 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.Address2));

#line default
#line hidden
            EndContext();
            BeginContext(852, 13, true);
            WriteLiteral(".\r\n\r\n        ");
            EndContext();
            BeginContext(866, 45, false);
#line 30 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.City));

#line default
#line hidden
            EndContext();
            BeginContext(911, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(915, 46, false);
#line 30 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
                                                    Write(Html.DisplayFor(model => model.Customer.State));

#line default
#line hidden
            EndContext();
            BeginContext(961, 13, true);
            WriteLiteral(".\r\n\r\n        ");
            EndContext();
            BeginContext(975, 48, false);
#line 32 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Customer.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1023, 104, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        Event\r\n\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(1128, 42, false);
#line 39 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Event.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1170, 11, true);
            WriteLiteral("\r\n        (");
            EndContext();
            BeginContext(1182, 42, false);
#line 40 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
    Write(Html.DisplayFor(model => model.Event.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1224, 17, true);
            WriteLiteral(")<br />\r\n        ");
            EndContext();
            BeginContext(1242, 42, false);
#line 41 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Event.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1284, 16, true);
            WriteLiteral("<br />\r\n        ");
            EndContext();
            BeginContext(1301, 42, false);
#line 42 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Event.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1343, 70, true);
            WriteLiteral("<br />\r\n        <br />\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        ");
            EndContext();
            BeginContext(1414, 40, false);
#line 46 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayNameFor(model => model.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(1454, 49, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
            EndContext();
            BeginContext(1504, 36, false);
#line 49 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\EventCustomers\DeleteAsync.cshtml"
   Write(Html.DisplayFor(model => model.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(1540, 49, true);
            WriteLiteral("\r\n    </dd>\r\n    </dl>\r\n</div>\r\n    \r\n<div>\r\n    ");
            EndContext();
            BeginContext(1589, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef82c14694eb05d9c43bb05d82d6ffd73231104011993", async() => {
                BeginContext(1620, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1703, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef82c14694eb05d9c43bb05d82d6ffd73231104012467", async() => {
                    BeginContext(1725, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1741, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1754, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project1_5_Library.EventCustomer> Html { get; private set; }
    }
}
#pragma warning restore 1591
