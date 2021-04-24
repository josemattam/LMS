#pragma checksum "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95e74186dd4e251fba2d2bb7188a0092537700cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Assignment), @"mvc.1.0.view", @"/Views/Student/Assignment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Assignment.cshtml", typeof(AspNetCore.Views_Student_Assignment))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95e74186dd4e251fba2d2bb7188a0092537700cc", @"/Views/Student/Assignment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Assignment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
  
    ViewData["Title"] = "Assignment";
    Layout = "~/Views/Shared/StudentLayout.cshtml";

#line default
#line hidden
            BeginContext(101, 145, true);
            WriteLiteral("\r\n\r\n<h4 id=\"asgname\">Assignment</h4>\r\n<div id=\"asgcontents\"></div>\r\n<hr />\r\n<h4>My Submission</h4>\r\n<div id=\"submissioncontents\"></div>\r\n<hr />\r\n");
            EndContext();
            BeginContext(298, 262, true);
            WriteLiteral(@"<div>
  <textarea rows=""4"" cols=""50"" name=""SubContents"" id=""SubContents"">Enter new submission</textarea>
</div>

<div>
  <input class=""btn btn-primary"" name=""submitButton"" id=""btnSave"" value=""Submit"" type=""button"" onclick=""SubmitAssignment()"">
</div>


");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(581, 202, true);
                WriteLiteral("\r\n  <script type=\"text/javascript\">\r\n\r\n    LoadData();\r\n\r\n    function SubmitAssignment() {\r\n\r\n      var subContents = $(\"#SubContents\").val();\r\n\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(784, 45, false);
#line 39 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
         Write(Url.Action("SubmitAssignmentText", "Student"));

#line default
#line hidden
                EndContext();
                BeginContext(829, 70, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(900, 19, false);
#line 43 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(919, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(947, 15, false);
#line 44 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(962, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(987, 18, false);
#line 45 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(1005, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(1034, 16, false);
#line 46 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(1050, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(1077, 15, false);
#line 47 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(1092, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(1117, 17, false);
#line 48 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(1134, 20, true);
                WriteLiteral("\',\r\n          uid: \'");
                EndContext();
                BeginContext(1155, 18, false);
#line 49 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
           Write(User.Identity.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1173, 473, true);
                WriteLiteral(@"',
          contents: subContents},
        success: function (data, status) {
          //alert(JSON.stringify(data));
          if (!data.success) {
            alert(""Unable to submit assignment"");
          }
          location.reload();
        },
          error: function (ex) {
              alert(""SubmitAssignmentText controller did not return successfully"");
        }
        });

    }

    function LoadData() {

      asgname.innerText = '");
                EndContext();
                BeginContext(1647, 17, false);
#line 67 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                      Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(1664, 59, true);
                WriteLiteral("\';\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(1724, 45, false);
#line 71 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
         Write(Url.Action("GetAssignmentContents", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(1769, 68, true);
                WriteLiteral("\',\r\n        dataType: \'text\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(1838, 19, false);
#line 74 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(1857, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(1885, 15, false);
#line 75 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(1900, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(1925, 18, false);
#line 76 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(1943, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(1972, 16, false);
#line 77 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(1988, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(2015, 15, false);
#line 78 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(2030, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(2055, 17, false);
#line 79 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(2072, 410, true);
                WriteLiteral(@"'},
        success: function (data, status) {
          //alert(data);

          var contentsdiv = document.getElementById(""asgcontents"");
          contentsdiv.innerHTML = data;
          
        },
          error: function (ex) {
              alert(""GetAssignmentContents controller did not return successfully"");
        }
      });


      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(2483, 41, false);
#line 95 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
         Write(Url.Action("GetSubmissionText", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(2524, 68, true);
                WriteLiteral("\',\r\n        dataType: \'text\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(2593, 19, false);
#line 98 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(2612, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(2640, 15, false);
#line 99 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(2655, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(2680, 18, false);
#line 100 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(2698, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(2727, 16, false);
#line 101 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(2743, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(2770, 15, false);
#line 102 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(2785, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(2810, 17, false);
#line 103 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(2827, 20, true);
                WriteLiteral("\',\r\n          uid: \'");
                EndContext();
                BeginContext(2848, 18, false);
#line 104 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Student\Assignment.cshtml"
           Write(User.Identity.Name);

#line default
#line hidden
                EndContext();
                BeginContext(2866, 526, true);
                WriteLiteral(@"'},
        success: function (data, status) {
          //alert(data);
          

          var submissiondiv = document.getElementById(""submissioncontents"");
          if (data == """") {
            submissiondiv.innerHTML = ""(none)"";
          }
          else {
            submissiondiv.innerHTML = data;
          }
          
        },
          error: function (ex) {
              alert(""GetSubmissionText controller did not return successfully"");
        }
        });


    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(3395, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
