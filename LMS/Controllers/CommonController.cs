using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LMS.Controllers
{
  public class CommonController : Controller
  {

    /*******Begin code to modify********/

    // TODO: Uncomment and change 'X' after you have scaffoled

    
    protected Team6LMSContext db;

    public CommonController()
    {
      db = new Team6LMSContext();
    }
    
    /*
     * WARNING: This is the quick and easy way to make the controller
     *          use a different LibraryContext - good enough for our purposes.
     *          The "right" way is through Dependency Injection via the constructor 
     *          (look this up if interested).
    */

    // TODO: Uncomment and change 'X' after you have scaffoled
    
    public void UseLMSContext(Team6LMSContext ctx)
    {
      db = ctx;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
    



    /// <summary>
    /// Retreive a JSON array of all departments from the database.
    /// Each object in the array should have a field called "name" and "subject",
    /// where "name" is the department name and "subject" is the subject abbreviation.
    /// </summary>
    /// <returns>The JSON array</returns>
    public IActionResult GetDepartments()
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from d in db.Departments
                            select new
                            {
                                name = d.Name,
                                subject = d.Subject
                            };
                return Json(query.ToArray());
            }

      // TODO: Do not return this hard-coded array.
      //return Json(new[] { new { name = "None", subject = "NONE" } });
    }



    /// <summary>
    /// Returns a JSON array representing the course catalog.
    /// Each object in the array should have the following fields:
    /// "subject": The subject abbreviation, (e.g. "CS")
    /// "dname": The department name, as in "Computer Science"
    /// "courses": An array of JSON objects representing the courses in the department.
    ///            Each field in this inner-array should have the following fields:
    ///            "number": The course number (e.g. 5530)
    ///            "cname": The course name (e.g. "Database Systems")
    /// </summary>
    /// <returns>The JSON array</returns>
    public IActionResult GetCatalog()
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from d in db.Departments
                            select new
                            {
                                subject = d.Subject,
                                dname = d.Name,
                                courses = from c in db.Courses
                                          where c.Subject == d.Subject
                                          select new
                                          {
                                              number = c.Num,
                                              cname = c.Name
                                          }
                            };

                return Json(query.ToArray());
            }

    }

    /// <summary>
    /// Returns a JSON array of all class offerings of a specific course.
    /// Each object in the array should have the following fields:
    /// "season": the season part of the semester, such as "Fall"
    /// "year": the year part of the semester
    /// "location": the location of the class
    /// "start": the start time in format "hh:mm:ss"
    /// "end": the end time in format "hh:mm:ss"
    /// "fname": the first name of the professor
    /// "lname": the last name of the professor
    /// </summary>
    /// <param name="subject">The subject abbreviation, as in "CS"</param>
    /// <param name="number">The course number, as in 5530</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetClassOfferings(string subject, int number)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from cl in db.Classes
                            join pu in db.Professors on cl.PId equals pu.UId
                            join u in db.Users on pu.UId equals u.UId
                            join co in db.Courses on cl.CId equals co.CId
                            where co.Subject == subject && co.Num == number
                            select new
                            {
                                season = cl.Season,
                                year = cl.Year,
                                location = cl.Loc,
                                start = cl.Start,
                                end = cl.End,
                                fname = u.FName,
                                lname = u.LName
                            };

                return Json(query.ToArray());
            }
        }

    /// <summary>
    /// This method does NOT return JSON. It returns plain text (containing html).
    /// Use "return Content(...)" to return plain text.
    /// Returns the contents of an assignment.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment in the category</param>
    /// <returns>The assignment contents</returns>
    public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                            join an in db.Assignments on ac.AcId equals an.AcId
                            where co.Subject == subject && co.Num == num &&
                                  cl.Year == year && cl.Season == season &&
                                  ac.Name == category && an.Name == asgname
                            select an.Contents;

                string jstr = JsonConvert.SerializeObject(Json(query.ToArray()));
                JObject jo = JObject.Parse(jstr);

                string cont = jo["Value"].ToString();
                return Content(cont);
            }
        }


    /// <summary>
    /// This method does NOT return JSON. It returns plain text (containing html).
    /// Use "return Content(...)" to return plain text.
    /// Returns the contents of an assignment submission.
    /// Returns the empty string ("") if there is no submission.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment in the category</param>
    /// <param name="uid">The uid of the student who submitted it</param>
    /// <returns>The submission text</returns>
    public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                            join an in db.Assignments on ac.AcId equals an.AcId
                            join su in db.Submissions on an.AId equals su.AId
                            where co.Subject == subject && co.Num == num &&
                                  cl.Year == year && cl.Season == season &&
                                  ac.Name == category && an.Name == asgname &&
                                  su.UId == uid
                            select su.Contents;
                //TODO: change tostr
                // special case: replace null with empty string
                if (query == null)
                    return Content("");

                string jstr = JsonConvert.SerializeObject(Json(query.ToArray()));
                JObject jo = JObject.Parse(jstr);

                string cont = jo["Value"].ToString();
                return Content(cont);
            }
    }


    /// <summary>
    /// Gets information about a user as a single JSON object.
    /// The object should have the following fields:
    /// "fname": the user's first name
    /// "lname": the user's last name
    /// "uid": the user's uid
    /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
    ///               If the user is a Professor, this is the department they work in.
    ///               If the user is a Student, this is the department they major in.    
    ///               If the user is an Administrator, this field is not present in the returned JSON
    /// </summary>
    /// <param name="uid">The ID of the user</param>
    /// <returns>
    /// The user JSON object 
    /// or an object containing {success: false} if the user doesn't exist
    /// </returns>
    public IActionResult GetUser(string uid)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from u in db.Users
                            where u.UId == uid
                            join p in db.Professors on u.UId equals p.UId into pujoin
                            from pu in pujoin.DefaultIfEmpty()
                            join s in db.Students on u.UId equals s.UId into spujoin
                            from spu in spujoin.DefaultIfEmpty()
                            join a in db.Administrators on u.UId equals a.UId into aspujoin
                            from aspu in aspujoin.DefaultIfEmpty()
                            select new
                            {
                                fname = u.FName,
                                lname = u.LName,
                                uid = u.UId,
                                // str to be replaced if admin, corresponding subject if student or professor
                                department = (aspu == null) ? "nullVal"  :  ((spu != null) ? 
                                                                            (from s in db.Students
                                                                             where s.UId == uid
                                                                             select s.Subject).ToString() :
                                                                                                pu.Subject)
                            };

                //special case if query fails
                if (query == null || Json(query) == null)
                    return Json(new { success = false });

                //return ReplaceNull(Json(query.ToArray()[0]));
                return ReplaceNull(Json(query.ToArray()[0]));
            }
    }

    /// <summary>
    /// Helper function to GetUser. If the user is an administrator, it removes the 
    /// json field of department from the returned JsonResult.
    /// </summary>
    /// <param name="jr"> the JsonResult that needs checking </param>
    /// <returns> In format JsonResult </returns>
    private IActionResult ReplaceNull(JsonResult jr)
    {
            //converts json to string
            string jstr = JsonConvert.SerializeObject(jr.Value);
            JObject jo = JObject.Parse(jstr);

            if (jstr.Contains("nullVal"))
            {
                jo.Property("department").Remove();
                return Json(jo);
            }
            return Json(jo);
    }


    /*******End code to modify********/

  }
}