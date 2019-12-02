#pragma checksum "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c87f809573d1783fe965c74dba008e354dafbea2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GroceryStores.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(GroceryStores.Pages.Pages_Index), null)]
namespace GroceryStores.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\_ViewImports.cshtml"
using GroceryStores;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c87f809573d1783fe965c74dba008e354dafbea2", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"593936eade9c57b79a04fe6facc8e3ae6e929cbe", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";
    List<BusinessOwnerDetails.BusinessOwner> businessOwners = (List<BusinessOwnerDetails.BusinessOwner>) ViewData["businessOwners"];
    

#line default
#line hidden
            BeginContext(213, 493, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Grocery Stores List</h1>

    <table class=""table table-bordered table-striped"">
        <thead class=""table-dark"">
            <tr>

                <th>License Id</th>
                <th>License Description</th>
                <th>Doing Business As Name</th>
                <th>Legal Name</th>
                <th>License Status</th>
                <th>Zipcode</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 26 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
              
                foreach (BusinessOwnerDetails.BusinessOwner buss in businessOwners)
                {

#line default
#line hidden
            BeginContext(826, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(881, 14, false);
#line 30 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.LicenseId);

#line default
#line hidden
            EndContext();
            BeginContext(895, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(931, 23, false);
#line 31 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.LicenseDescription);

#line default
#line hidden
            EndContext();
            BeginContext(954, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(990, 24, false);
#line 32 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.DoingBusinessAsName);

#line default
#line hidden
            EndContext();
            BeginContext(1014, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1050, 14, false);
#line 33 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.LegalName);

#line default
#line hidden
            EndContext();
            BeginContext(1064, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1100, 18, false);
#line 34 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.LicenseStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1118, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1154, 12, false);
#line 35 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                       Write(buss.ZipCode);

#line default
#line hidden
            EndContext();
            BeginContext(1166, 36, true);
            WriteLiteral("</td>\r\n\r\n                    </tr>\r\n");
            EndContext();
#line 38 "C:\Users\gnsni\Desktop\GroceryStores\GroceryStores\GroceryStores\Pages\Index.cshtml"
                }
            

#line default
#line hidden
            BeginContext(1236, 44, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591