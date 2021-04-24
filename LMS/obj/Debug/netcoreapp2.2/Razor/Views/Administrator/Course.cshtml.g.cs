#pragma checksum "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85de11c8e9d7642ea46d7c7e7c95b59e9487a631"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_Course), @"mvc.1.0.view", @"/Views/Administrator/Course.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrator/Course.cshtml", typeof(AspNetCore.Views_Administrator_Course))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85de11c8e9d7642ea46d7c7e7c95b59e9487a631", @"/Views/Administrator/Course.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_Course : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Spring", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Summer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Fall", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
  
    ViewData["Title"] = "Course";
    Layout = "~/Views/Shared/AdministratorLayout.cshtml";

#line default
#line hidden
            BeginContext(103, 41, true);
            WriteLiteral("\r\n<h4 id=\"classname\">Class offerings for ");
            EndContext();
            BeginContext(145, 19, false);
#line 7 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
                                  Write(ViewData["subject"]);

#line default
#line hidden
            EndContext();
            BeginContext(164, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(166, 15, false);
#line 7 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
                                                       Write(ViewData["num"]);

#line default
#line hidden
            EndContext();
            BeginContext(181, 999, true);
            WriteLiteral(@"</h4>

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
          </tr>
        </thead>
        <tbody></tbody>
      </table>
    </div>
  </div>
</div>


<div class=""col-md-12"">
  <div class=""panel panel-primary"">
    <div class=""panel-heading"">
      <h3 class=""panel-title"">New Class</h3>
    </div>
    <div class=""panel-body"">
      <div class=""form-group col-md-5"">

        <label>Season</label>
        <select id=""SeasonSelector"">
          ");
            EndContext();
            BeginContext(1180, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85de11c8e9d7642ea46d7c7e7c95b59e9487a6316578", async() => {
                BeginContext(1203, 6, true);
                WriteLiteral("Spring");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1218, 12, true);
            WriteLiteral("\r\n          ");
            EndContext();
            BeginContext(1230, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85de11c8e9d7642ea46d7c7e7c95b59e9487a6317965", async() => {
                BeginContext(1253, 6, true);
                WriteLiteral("Summer");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1268, 12, true);
            WriteLiteral("\r\n          ");
            EndContext();
            BeginContext(1280, 34, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85de11c8e9d7642ea46d7c7e7c95b59e9487a6319352", async() => {
                BeginContext(1301, 4, true);
                WriteLiteral("Fall");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1314, 1341, true);
            WriteLiteral(@"
        </select>

        <input type=""text"" name=""ClassYear"" id=""ClassYear"" class=""form-control"" placeholder=""Enter semester year"" required="""" />
      </div>
      <div class=""form-group col-md-5"">

        <div class=""control"">
          <label for=""start-time"">Start Time:</label>
          <input type=""time"" id=""StartTime"" name=""StartTime""
                 min=""06:00"" max=""20:00"" value=""06:00"" required />
        </div>
        <div class=""control"">
          <label for=""end-time"">End Time:</label>
          <input type=""time"" id=""EndTime"" name=""EndTime""
                 min=""06:00"" max=""20:00"" value=""07:20"" required />
        </div>

      </div>

      <div class=""form-group col-md-5"">

        <label>Instructor</label>
        <select id=""ProfSelector"">
        </select>

      </div>

      <div class=""form-group col-md-5"">

        <label>Location</label>
        <input type=""text"" name=""Location"" id=""Location"" class=""form-control"" placeholder=""Enter location"" requir");
            WriteLiteral(@"ed="""" />

      </div>

      <div class=""form-group col-md-1"">
        <div style=""float: right; display:inline-block;"">
          <input class=""btn btn-primary"" name=""submitButton"" id=""btnSave"" value=""Add"" type=""button"" onclick=""AddClass()"">
        </div>
      </div>
    </div>
  </div>
</div>



");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2676, 416, true);
                WriteLiteral(@"
  <script type=""text/javascript"">

    LoadData();

    function AddClass() {

      var claSeason = $(""#SeasonSelector"").val();
      var claYear = Number($(""#ClassYear"").val());
      var startTime = $(""#StartTime"").val();
      var endTime = $(""#EndTime"").val();
      var prof = $(""#ProfSelector"").val();
      var loc = $(""#Location"").val();

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(3093, 42, false);
#line 106 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
         Write(Url.Action("CreateClass", "Administrator"));

#line default
#line hidden
                EndContext();
                BeginContext(3135, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(3204, 19, false);
#line 109 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3223, 30, true);
                WriteLiteral("\',\r\n          number: Number(\'");
                EndContext();
                BeginContext(3254, 15, false);
#line 110 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
                     Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3269, 2021, true);
                WriteLiteral(@"'),
          season: claSeason,
          year: claYear,
          start: startTime,
          end: endTime,
          location: loc,
          instructor: prof
          },
        success: function (data, status) {
          //alert(JSON.stringify(data));
          if (!data.success) {
            alert(""Unable to add class"");
          }
          location.reload();
        },
        error: function (ex) {
            alert(""CreateClass controller did not return successfully"");
        }
        });

    }


    function PopulateInstructors(selector, instructors) {
      $.each(instructors, function (i, item) {

        var newOption = document.createElement(""option"");
        newOption.text = item.lname + "", "" + item.fname + "": "" + item.uid;
        newOption.value = item.uid;
        selector.add(newOption);

      });

    }

    function PopulateTable(tbl, offerings) {
      var newBody = document.createElement(""tbody"");

      $.each(offerings, function (i, item");
                WriteLiteral(@") {
        var tr = document.createElement(""tr"");

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.season + "" "" + item.year));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.location));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.start + "" - "" + item.end));
        tr.appendChild(td);

        var td = document.createElement(""td"");
        td.appendChild(document.createTextNode(item.lname + "", "" + item.fname));
        tr.appendChild(td);

        newBody.appendChild(tr);
      });

      tbl.appendChild(newBody);

    }

    function LoadData() {

      var tbl = document.getElementById(""tblClasses"");
      var body = tbl.getElementsByTagName(""tbody"")[0];
      tbl.removeChild(body);

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(5291, 41, false);
#line 182 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
         Write(Url.Action("GetClassOfferings", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(5332, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(5401, 19, false);
#line 185 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(5420, 30, true);
                WriteLiteral("\',\r\n          number: Number(\'");
                EndContext();
                BeginContext(5451, 15, false);
#line 186 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
                     Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(5466, 417, true);
                WriteLiteral(@"')
        },
          success: function (data, status) {
            //alert(JSON.stringify(data));
            PopulateTable(tbl, data);
          },
          error: function (ex) {
            alert(""GetClassOfferings controller did not return successfully"");
          }
      });

      var selector = document.getElementById(""ProfSelector"");

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(5884, 44, false);
#line 201 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
         Write(Url.Action("GetProfessors", "Administrator"));

#line default
#line hidden
                EndContext();
                BeginContext(5928, 68, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(5997, 19, false);
#line 204 "C:\Users\mhrsh\Desktop\cs3\LMS\LMS\Views\Administrator\Course.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(6016, 331, true);
                WriteLiteral(@"'
        },
          success: function (data, status) {
//            alert(JSON.stringify(data));
            PopulateInstructors(selector, data);
          },
          error: function (ex) {
            alert(""GetProfessors controller did not return successfully"");
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
