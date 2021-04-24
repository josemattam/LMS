#pragma checksum "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "653ae4488ae2119b23bad2fa87c7ee91315301c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_Index), @"mvc.1.0.view", @"/Views/Administrator/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrator/Index.cshtml", typeof(AspNetCore.Views_Administrator_Index))]
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
#line 1 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"653ae4488ae2119b23bad2fa87c7ee91315301c2", @"/Views/Administrator/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/AdministratorLayout.cshtml";

#line default
#line hidden
            BeginContext(102, 69, true);
            WriteLiteral("\r\n<h2>Departments</h2>\r\n\r\n<ul id=\"lstDepartments\">\r\n</ul>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(192, 819, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();


    function PopulateList(lst, departments) {

      departments.sort(function (a, b) {
        return a.subject.localeCompare(b.subject);

      });

      $.each(departments, function (i, item) {
        var li = document.createElement(""li"");
        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
          a.setAttribute(""href"", ""/Administrator/Department/?subject="" + item.subject);
        a.appendChild(document.createTextNode(item.subject));
        li.appendChild(a);
        lst.appendChild(li);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      var lst = document.getElementById(""lstDepartments"");

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(1012, 38, false);
#line 50 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Index.cshtml"
         Write(Url.Action("GetDepartments", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(1050, 340, true);
                WriteLiteral(@"',
        dataType: 'json',
        success: function (data, status) {

          PopulateList(lst, data);

          //alert(JSON.stringify(data));
          
        },
          error: function (ex) {
              alert(""GetDepartments controller did not return successfully"");
        }
        });
    }

  </script>
");
                EndContext();
            }
            );
            BeginContext(1393, 4, true);
            WriteLiteral("\r\n\r\n");
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
