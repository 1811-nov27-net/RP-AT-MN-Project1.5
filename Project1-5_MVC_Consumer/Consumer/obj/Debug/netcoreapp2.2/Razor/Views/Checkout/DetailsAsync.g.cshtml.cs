#pragma checksum "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25d7dba88023800e58e8c7408154e1c7424df4b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_DetailsAsync), @"mvc.1.0.view", @"/Views/Checkout/DetailsAsync.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Checkout/DetailsAsync.cshtml", typeof(AspNetCore.Views_Checkout_DetailsAsync))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25d7dba88023800e58e8c7408154e1c7424df4b8", @"/Views/Checkout/DetailsAsync.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7669a2734c33a8de67105ad519fa53565cc724", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_DetailsAsync : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Consumer.Models.CheckoutView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckoutAsync", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
            BeginContext(83, 112, true);
            WriteLiteral("\r\n<div>\r\n    <h4>Reservation</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(196, 50, false);
#line 12 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Reservation.Id));

#line default
#line hidden
            EndContext();
            BeginContext(246, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(308, 46, false);
#line 15 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Id));

#line default
#line hidden
            EndContext();
            BeginContext(354, 129, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Customer\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(484, 57, false);
#line 21 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.Name));

#line default
#line hidden
            EndContext();
            BeginContext(541, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(562, 62, false);
#line 22 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(624, 22, true);
            WriteLiteral("<br />\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 646, "\"", 719, 2);
            WriteAttributeValue("", 653, "mailto:", 653, 7, true);
#line 23 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 660, Html.DisplayFor(model => model.Reservation.Customer.Email), 660, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(720, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(722, 58, false);
#line 23 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
                                                                                    Write(Html.DisplayFor(model => model.Reservation.Customer.Email));

#line default
#line hidden
            EndContext();
            BeginContext(780, 24, true);
            WriteLiteral("</a><br />\r\n            ");
            EndContext();
            BeginContext(805, 61, false);
#line 24 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.Address1));

#line default
#line hidden
            EndContext();
            BeginContext(866, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(882, 61, false);
#line 25 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.Address2));

#line default
#line hidden
            EndContext();
            BeginContext(943, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(959, 57, false);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.City));

#line default
#line hidden
            EndContext();
            BeginContext(1016, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1020, 58, false);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
                                                                    Write(Html.DisplayFor(model => model.Reservation.Customer.State));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(1094, 60, false);
#line 27 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Customer.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1154, 125, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Room\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1280, 51, false);
#line 33 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Room.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1331, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(1352, 57, false);
#line 34 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Room.RoomType));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(1430, 53, false);
#line 35 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Room.Beds));

#line default
#line hidden
            EndContext();
            BeginContext(1483, 27, true);
            WriteLiteral(" Beds<br />\r\n            $ ");
            EndContext();
            BeginContext(1511, 53, false);
#line 36 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
         Write(Html.DisplayFor(model => model.Reservation.Room.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1564, 125, true);
            WriteLiteral(" (per day)\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Events\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
            EndContext();
#line 42 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
             foreach (var item in Model.EventsCustomer)
            {
                

#line default
#line hidden
            BeginContext(1778, 41, false);
#line 44 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
           Write(Html.DisplayFor(model => item.Event.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1838, 41, false);
#line 45 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
           Write(Html.DisplayFor(model => item.Event.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1879, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 46 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
            }

#line default
#line hidden
            BeginContext(1902, 58, true);
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1961, 57, false);
#line 49 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Reservation.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(2018, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2080, 53, false);
#line 52 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(2133, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2194, 55, false);
#line 55 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Reservation.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(2249, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2311, 51, false);
#line 58 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(2362, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2423, 52, false);
#line 61 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Reservation.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(2475, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2537, 48, false);
#line 64 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Reservation.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(2585, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2646, 45, false);
#line 67 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(2691, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2753, 41, false);
#line 70 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(2794, 49, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2843, 671, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25d7dba88023800e58e8c7408154e1c7424df4b816193", async() => {
                BeginContext(2876, 40, true);
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"Id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2916, "\"", 2945, 1);
#line 77 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 2924, Model.Reservation.Id, 2924, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2946, 51, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"CustomerId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2997, "\"", 3034, 1);
#line 78 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 3005, Model.Reservation.CustomerId, 3005, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3035, 47, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"RoomId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3082, "\"", 3115, 1);
#line 79 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 3090, Model.Reservation.RoomId, 3090, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3116, 50, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"StartDate\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3166, "\"", 3202, 1);
#line 80 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 3174, Model.Reservation.StartDate, 3174, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3203, 48, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"EndDate\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3251, "\"", 3285, 1);
#line 81 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 3259, Model.Reservation.EndDate, 3259, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3286, 50, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"TotalCost\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3336, "\"", 3372, 1);
#line 82 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Checkout\DetailsAsync.cshtml"
WriteAttributeValue("", 3344, Model.Reservation.TotalCost, 3344, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3373, 90, true);
                WriteLiteral(" />\r\n\r\n        <input type=\"submit\" value=\"Checkout\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(3463, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25d7dba88023800e58e8c7408154e1c7424df4b819705", async() => {
                    BeginContext(3485, 12, true);
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
                BeginContext(3501, 6, true);
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
            BeginContext(3514, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Consumer.Models.CheckoutView> Html { get; private set; }
    }
}
#pragma warning restore 1591
