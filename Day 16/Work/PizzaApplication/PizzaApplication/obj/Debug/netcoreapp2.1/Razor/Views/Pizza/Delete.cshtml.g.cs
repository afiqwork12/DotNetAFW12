#pragma checksum "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf455223fa7a553f3e9c03ce73afffc069a86844"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pizza_Delete), @"mvc.1.0.view", @"/Views/Pizza/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pizza/Delete.cshtml", typeof(AspNetCore.Views_Pizza_Delete))]
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
#line 1 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\_ViewImports.cshtml"
using PizzaApplication;

#line default
#line hidden
#line 2 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\_ViewImports.cshtml"
using PizzaApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf455223fa7a553f3e9c03ce73afffc069a86844", @"/Views/Pizza/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba295415eabbe47cee94bfd856e3b8f99d2f3b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Pizza_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PizzaApplication.Models.Pizza>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(82, 166, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Pizza</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(249, 38, false);
#line 15 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(287, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(331, 34, false);
#line 18 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(365, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(409, 40, false);
#line 21 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(449, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(493, 36, false);
#line 24 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(529, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(573, 41, false);
#line 27 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsVeg));

#line default
#line hidden
            EndContext();
            BeginContext(614, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(658, 37, false);
#line 30 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsVeg));

#line default
#line hidden
            EndContext();
            BeginContext(695, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(739, 41, false);
#line 33 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(780, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(824, 37, false);
#line 36 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(861, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(905, 39, false);
#line 39 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Pic));

#line default
#line hidden
            EndContext();
            BeginContext(944, 47, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 991, "\"", 1020, 1);
#line 42 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
WriteAttributeValue("", 997, Url.Content(Model.Pic), 997, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1021, 51, true);
            WriteLiteral(" alt=\"Alternate Text\" width=\"150\" height=\"150\" />\r\n");
            EndContext();
            BeginContext(1126, 41, true);
            WriteLiteral("        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1168, 43, false);
#line 46 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Details));

#line default
#line hidden
            EndContext();
            BeginContext(1211, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1255, 39, false);
#line 49 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Work\PizzaApplication\PizzaApplication\Views\Pizza\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Details));

#line default
#line hidden
            EndContext();
            BeginContext(1294, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1332, 161, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c50ad1dcb5fc49f8b6e7bc9a6a242554", async() => {
                BeginContext(1358, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1442, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3b71cb46f4a459a9eec6af711000793", async() => {
                    BeginContext(1464, 12, true);
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
                BeginContext(1480, 6, true);
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
            BeginContext(1493, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PizzaApplication.Models.Pizza> Html { get; private set; }
    }
}
#pragma warning restore 1591
