#pragma checksum "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14dd783b8f04817aad604a35790cbf6bd8025323"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Delete), @"mvc.1.0.view", @"/Views/Product/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Delete.cshtml", typeof(AspNetCore.Views_Product_Delete))]
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
#line 1 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\_ViewImports.cshtml"
using ProductApplication;

#line default
#line hidden
#line 2 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\_ViewImports.cshtml"
using ProductApplication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14dd783b8f04817aad604a35790cbf6bd8025323", @"/Views/Product/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de38edaa17aee1002e0950cdb09d0d2c5e536e2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductApplication.Models.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
  
    ViewData["Title"] = "Delete Product";

#line default
#line hidden
#line 5 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
 using (Html.BeginForm("Delete", "Product", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(158, 116, true);
            WriteLiteral("    <h1>Product Details</h1>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product ID</label>\r\n        ");
            EndContext();
            BeginContext(275, 83, false);
#line 10 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextBoxFor(m => m.Id, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(358, 102, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product Name</label>\r\n        ");
            EndContext();
            BeginContext(461, 85, false);
#line 14 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(546, 103, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product Price</label>\r\n        ");
            EndContext();
            BeginContext(650, 86, false);
#line 18 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextBoxFor(m => m.Price, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(736, 109, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product Supplier Id</label>\r\n        ");
            EndContext();
            BeginContext(846, 91, false);
#line 22 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextBoxFor(m => m.SupplierId, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(937, 106, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product Quantity</label>\r\n        ");
            EndContext();
            BeginContext(1044, 89, false);
#line 26 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextBoxFor(m => m.Quantity, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(1133, 105, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Product Remarks</label>\r\n        ");
            EndContext();
            BeginContext(1239, 89, false);
#line 30 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
   Write(Html.TextAreaFor(m => m.Remarks, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(1328, 164, true);
            WriteLiteral("\r\n    </div>\r\n    <br />\r\n    <div class=\"mb-3\">\r\n        <input class=\"btn btn-danger\" type=\"submit\" name=\"submit\" value=\"Confirm Delete Product?\" />\r\n    </div>\r\n");
            EndContext();
#line 36 "C:\Users\Afiq\Documents\GitHub\DotNetAFW12\Day 16\Assignment\ProductSolution\ProductApplication\Views\Product\Delete.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductApplication.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591