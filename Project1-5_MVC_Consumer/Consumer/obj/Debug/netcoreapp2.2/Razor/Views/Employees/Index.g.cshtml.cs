#pragma checksum "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14b1b8d7e3ecfdda9e390b18cfd48a9651e17947"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Index), @"mvc.1.0.view", @"/Views/Employees/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employees/Index.cshtml", typeof(AspNetCore.Views_Employees_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14b1b8d7e3ecfdda9e390b18cfd48a9651e17947", @"/Views/Employees/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc7669a2734c33a8de67105ad519fa53565cc724", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project1_5_Library.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateAsync", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(121, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b1b8d7e3ecfdda9e390b18cfd48a9651e179473880", async() => {
                BeginContext(149, 20, true);
                WriteLiteral("Create New Employees");
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
            BeginContext(173, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(266, 38, false);
#line 16 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(304, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(360, 40, false);
#line 19 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(400, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(456, 42, false);
#line 22 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
            EndContext();
            BeginContext(498, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(554, 40, false);
#line 25 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
            EndContext();
            BeginContext(594, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(712, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(761, 37, false);
#line 34 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(798, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(854, 39, false);
#line 37 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(893, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(949, 41, false);
#line 40 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
            EndContext();
            BeginContext(990, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1046, 39, false);
#line 43 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Role));

#line default
#line hidden
            EndContext();
            BeginContext(1085, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1141, 59, false);
#line 46 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.ActionLink("Edit", "EditAsync", new {  id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1200, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1221, 64, false);
#line 47 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.ActionLink("Details", "DetailsAsync", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1285, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1306, 62, false);
#line 48 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
           Write(Html.ActionLink("Delete", "DeleteAsync", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1368, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 51 "C:\Revature\Projects\Project1-5\Project1-5_MVC_Consumer\Consumer\Views\Employees\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1407, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project1_5_Library.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
