#pragma checksum "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "101051e797c82e155b9e2583212d6d06e9aa0f5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers_DetailsAsync), @"mvc.1.0.view", @"/Views/Customers/DetailsAsync.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customers/DetailsAsync.cshtml", typeof(AspNetCore.Views_Customers_DetailsAsync))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"101051e797c82e155b9e2583212d6d06e9aa0f5c", @"/Views/Customers/DetailsAsync.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7669a2734c33a8de67105ad519fa53565cc724", @"/Views/_ViewImports.cshtml")]
    public class Views_Customers_DetailsAsync : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project1_5_Library.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
  
    ViewData["Title"] = "DetailsAsync";

#line default
#line hidden
            BeginContext(86, 136, true);
            WriteLiteral("\r\n<h1>DetailsAsync</h1>\r\n\r\n<div>\r\n    <h4>Customer</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(223, 38, false);
#line 14 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(261, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(325, 34, false);
#line 17 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(359, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(422, 40, false);
#line 20 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(462, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(526, 36, false);
#line 23 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(562, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(625, 41, false);
#line 26 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(666, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(730, 37, false);
#line 29 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(767, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(830, 44, false);
#line 32 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Address1));

#line default
#line hidden
            EndContext();
            BeginContext(874, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(938, 40, false);
#line 35 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Address1));

#line default
#line hidden
            EndContext();
            BeginContext(978, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1041, 44, false);
#line 38 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Address2));

#line default
#line hidden
            EndContext();
            BeginContext(1085, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1149, 40, false);
#line 41 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Address2));

#line default
#line hidden
            EndContext();
            BeginContext(1189, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1252, 40, false);
#line 44 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1292, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1356, 36, false);
#line 47 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1392, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1455, 41, false);
#line 50 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
            EndContext();
            BeginContext(1496, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1560, 37, false);
#line 53 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.State));

#line default
#line hidden
            EndContext();
            BeginContext(1597, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1660, 43, false);
#line 56 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1703, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1767, 39, false);
#line 59 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1806, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1869, 44, false);
#line 62 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.CardInfo));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1977, 40, false);
#line 65 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.CardInfo));

#line default
#line hidden
            EndContext();
            BeginContext(2017, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2080, 45, false);
#line 68 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayNameFor(model => model.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(2125, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2189, 41, false);
#line 71 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
       Write(Html.DisplayFor(model => model.BirthDate));

#line default
#line hidden
            EndContext();
            BeginContext(2230, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2278, 73, false);
#line 76 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Customers\DetailsAsync.cshtml"
Write(Html.ActionLink("Edit", "EditAsync", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2351, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2359, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "101051e797c82e155b9e2583212d6d06e9aa0f5c13294", async() => {
                BeginContext(2381, 12, true);
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
            BeginContext(2397, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project1_5_Library.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591