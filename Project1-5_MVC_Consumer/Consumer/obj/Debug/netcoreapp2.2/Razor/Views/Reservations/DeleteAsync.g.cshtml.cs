#pragma checksum "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9332c4baae96c438232c92848c4b19e8337cc51f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations_DeleteAsync), @"mvc.1.0.view", @"/Views/Reservations/DeleteAsync.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reservations/DeleteAsync.cshtml", typeof(AspNetCore.Views_Reservations_DeleteAsync))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9332c4baae96c438232c92848c4b19e8337cc51f", @"/Views/Reservations/DeleteAsync.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7669a2734c33a8de67105ad519fa53565cc724", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservations_DeleteAsync : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project1_5_Library.Reservation>
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
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
  
    ViewData["Title"] = "DeleteAsync";

#line default
#line hidden
            BeginContext(88, 184, true);
            WriteLiteral("\r\n<h1>DeleteAsync</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Reservation</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(273, 38, false);
#line 15 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(311, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(373, 34, false);
#line 18 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(407, 129, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Customer\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(537, 45, false);
#line 24 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Name));

#line default
#line hidden
            EndContext();
            BeginContext(582, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(603, 50, false);
#line 25 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(653, 22, true);
            WriteLiteral("<br />\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 675, "\"", 736, 2);
            WriteAttributeValue("", 682, "mailto:", 682, 7, true);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
WriteAttributeValue("", 689, Html.DisplayFor(model => model.Customer.Email), 689, 47, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(737, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(739, 46, false);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Customer.Email));

#line default
#line hidden
            EndContext();
            BeginContext(785, 24, true);
            WriteLiteral("</a><br />\r\n            ");
            EndContext();
            BeginContext(810, 49, false);
#line 27 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Address1));

#line default
#line hidden
            EndContext();
            BeginContext(859, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(875, 49, false);
#line 28 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Address2));

#line default
#line hidden
            EndContext();
            BeginContext(924, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(940, 45, false);
#line 29 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.City));

#line default
#line hidden
            EndContext();
            BeginContext(985, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(989, 46, false);
#line 29 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
                                                        Write(Html.DisplayFor(model => model.Customer.State));

#line default
#line hidden
            EndContext();
            BeginContext(1035, 15, true);
            WriteLiteral(".\r\n            ");
            EndContext();
            BeginContext(1051, 48, false);
#line 30 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 125, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Room\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1225, 39, false);
#line 36 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Room.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1264, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(1285, 45, false);
#line 37 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Room.RoomType));

#line default
#line hidden
            EndContext();
            BeginContext(1330, 20, true);
            WriteLiteral("<br />\r\n            ");
            EndContext();
            BeginContext(1351, 41, false);
#line 38 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Room.Beds));

#line default
#line hidden
            EndContext();
            BeginContext(1392, 27, true);
            WriteLiteral(" Beds<br />\r\n            $ ");
            EndContext();
            BeginContext(1420, 41, false);
#line 39 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
         Write(Html.DisplayFor(model => model.Room.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1461, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1522, 45, false);
#line 42 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(1567, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1629, 41, false);
#line 45 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(1670, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1731, 43, false);
#line 48 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1774, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1836, 39, false);
#line 51 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1875, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1936, 40, false);
#line 54 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(1976, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2038, 36, false);
#line 57 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.Paid));

#line default
#line hidden
            EndContext();
            BeginContext(2074, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2135, 45, false);
#line 60 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(2180, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2242, 41, false);
#line 63 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Reservations\DeleteAsync.cshtml"
       Write(Html.DisplayFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(2283, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2321, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9332c4baae96c438232c92848c4b19e8337cc51f14782", async() => {
                BeginContext(2352, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(2435, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9332c4baae96c438232c92848c4b19e8337cc51f15256", async() => {
                    BeginContext(2457, 12, true);
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
                BeginContext(2473, 6, true);
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
            BeginContext(2486, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project1_5_Library.Reservation> Html { get; private set; }
    }
}
#pragma warning restore 1591