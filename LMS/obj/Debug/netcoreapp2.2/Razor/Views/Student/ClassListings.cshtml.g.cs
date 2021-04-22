#pragma checksum "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0e4ee3b20637386d8ef0845cc4b63d46d1ce711"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_ClassListings), @"mvc.1.0.view", @"/Views/Student/ClassListings.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/ClassListings.cshtml", typeof(AspNetCore.Views_Student_ClassListings))]
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
#line 1 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e4ee3b20637386d8ef0845cc4b63d46d1ce711", @"/Views/Student/ClassListings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_ClassListings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
  
    ViewData["Title"] = "ClassListings";
    Layout = "~/Views/Shared/StudentLayout.cshtml";

#line default
#line hidden
            BeginContext(104, 714, true);
            WriteLiteral(@"
<h4 id=""classname"">ClassListings</h4>

<div id=""departmentDiv"" class=""col-md-12"">
  <div class=""panel panel-primary"">
    <div class=""panel-heading"">
      <h3 class=""panel-title""></h3>
    </div>
    <div class=""panel-body"">
      <table id=""tblClasses"" class=""table table-bordered table-striped table-responsive table-hover"">
        <thead>
          <tr>
            <th align=""left"" class=""productth"">Semester</th>
            <th align=""left"" class=""productth"">Location</th>
            <th align=""left"" class=""productth"">Time</th>
            <th align=""left"" class=""productth"">Instructor</th>
            <th align=""left"" class=""productth"">Options</th>
          </tr>
        </thead>
");
            EndContext();
            BeginContext(847, 52, true);
            WriteLiteral("      </table>\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(920, 152, true);
                WriteLiteral("\r\n  <script type=\"text/javascript\">\r\n\r\n    LoadData();\r\n\r\n    function Enroll(_season, _year) {\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(1073, 31, false);
#line 43 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
         Write(Url.Action("Enroll", "Student"));

#line default
#line hidden
                EndContext();
                BeginContext(1104, 70, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(1175, 19, false);
#line 47 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(1194, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(1222, 15, false);
#line 48 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(1237, 73, true);
                WriteLiteral("\'),\r\n          season: _season,\r\n          year: _year,\r\n          uid: \'");
                EndContext();
                BeginContext(1311, 18, false);
#line 51 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
           Write(User.Identity.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1329, 1858, true);
                WriteLiteral(@"',
          },
        success: function (data, status) {
          //alert(JSON.stringify(data));
          if (data.success == undefined) {
            alert(""Unknown response from controller"");
          }
          else if (data.success == true) {
            alert(""Successfully enrolled in class"");
          }
          else{
            alert(""Unable to enroll in class"");
          }
        },
          error: function (ex) {
              alert(""Enroll controller did not return successfully"");
        }
        });

    }

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");


      $.each(offerings, function (i, item) {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.season + "" "" + item.year));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.locat");
                WriteLiteral(@"ion));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.start + "" - "" + item.end));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.lname + "", "" + item.fname));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        var a = document.createElement(""a"");
        a.setAttribute(""href"", ""javascript:Enroll('"" + item.season + ""', '"" + item.year + ""')"");
        a.appendChild(document.createTextNode(""enroll""));
        td.appendChild(a);
        tr.appendChild(td);


        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      classname.innerText = 'Offerings of ");
                EndContext();
                BeginContext(3188, 19, false);
#line 112 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
                                     Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3207, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3209, 15, false);
#line 112 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
                                                          Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3224, 117, true);
                WriteLiteral("\';\r\n\r\n      var tbl = document.getElementById(\"tblClasses\");\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(3342, 41, false);
#line 118 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
         Write(Url.Action("GetClassOfferings", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(3383, 57, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: { subject: \'");
                EndContext();
                BeginContext(3441, 19, false);
#line 120 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
                     Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3460, 19, true);
                WriteLiteral("\', number: Number(\'");
                EndContext();
                BeginContext(3480, 15, false);
#line 120 "C:\Users\Jose\Downloads\LMS_handout\LMS\Views\Student\ClassListings.cshtml"
                                                            Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3495, 320, true);
                WriteLiteral(@"') },
        success: function (data, status) {

          PopulateTable(tbl, data);

          //alert(JSON.stringify(data));
          
        },
          error: function (ex) {
              alert(""GetClassOfferings controller did not return successfully"");
        }
        });
    }

  </script>
");
                EndContext();
            }
            );
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
