using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Models.LMSModels;

namespace LMS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Department(string subject)
        {
            ViewData["subject"] = subject;
            return View();
        }

        public IActionResult Course(string subject, string num)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }

        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of all the courses in the given department.
        /// Each object in the array should have the following fields:
        /// "number" - The course number (as in 5530)
        /// "name" - The course name (as in "Database Systems")
        /// </summary>
        /// <param name="subject">The department subject abbreviation (as in "CS")</param>
        /// <returns>The JSON result</returns>
        public IActionResult GetCourses(string subject)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from t in db.Courses
                            where t.Subject.Equals(subject)
                            select new
                            {
                                number = t.Num,
                                name = t.Name
                            };
                return Json(query.ToArray());
            }
        }





        /// <summary>
        /// Returns a JSON array of all the professors working in a given department.
        /// Each object in the array should have the following fields:
        /// "lname" - The professor's last name
        /// "fname" - The professor's first name
        /// "uid" - The professor's uid
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <returns>The JSON result</returns>
        public IActionResult GetProfessors(string subject)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from t in db.Professors
                            where t.Subject.Equals(subject)
                            join i in db.Users on t.UId equals i.UId into inv
                            from j1 in inv.DefaultIfEmpty()
                            select new
                            {
                                fname = j1.FName,
                                lname = j1.LName,
                                uid = j1.UId
                            };
                return Json(query.ToArray());
            }
        }



        /// <summary>
        /// Creates a course.
        /// A course is uniquely identified by its number + the subject to which it belongs
        /// </summary>
        /// <param name="subject">The subject abbreviation for the department in which the course will be added</param>
        /// <param name="number">The course number</param>
        /// <param name="name">The course name</param>
        /// <returns>A JSON object containing {success = true/false},
        /// false if the Course already exists.</returns>
        public IActionResult CreateCourse(string subject, int number, string name)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                try
                {
                    var query2 = from a in db.Courses
                                 where a.Subject.Equals(subject) && a.Num == number
                                 select a.CId;
                    if (query2.Any())
                    {
                        return Json(new { success = false });
                    }
                    else
                    {
                        var query = from a in db.Courses
                                    select a.CId;

                        bool cond = true;
                        string s = string.Empty;
                        while (true)
                        {
                            var random = new Random();
                            s = "";
                            for (int i = 0; i < 3; i++)
                                s = String.Concat(s, random.Next(10).ToString());

                            foreach (int U in query)
                            {
                                if (U.ToString().Equals(s))
                                {
                                    cond = false;
                                }
                            }
                            if (cond)
                            {
                                break;
                            }

                        }

                        Courses newCourse = new Courses();
                        newCourse.Name = name;
                        newCourse.Num = number;
                        newCourse.Subject = subject;
                        newCourse.CId = Int32.Parse(s);
                        db.Courses.Add(newCourse);
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false });
                }
            }
        }



        /// <summary>
        /// Creates a class offering of a given course.
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <param name="number">The course number</param>
        /// <param name="season">The season part of the semester</param>
        /// <param name="year">The year part of the semester</param>
        /// <param name="start">The start time</param>
        /// <param name="end">The end time</param>
        /// <param name="location">The location</param>
        /// <param name="instructor">The uid of the professor</param>
        /// <returns>A JSON object containing {success = true/false}. 
        /// false if another class occupies the same location during any time 
        /// within the start-end range in the same semester, or if there is already
        /// a Class offering of the same Course in the same Semester.</returns>
        public IActionResult CreateClass(string subject, int number, string season, int year, DateTime start, DateTime end, string location, string instructor)
        {

            using (Team6LMSContext db = new Team6LMSContext())
            {
                try
                {
                    var query2 = from a in db.Courses
                                 where a.Subject.Equals(subject) && a.Num == number
                                 select a.CId;
                    int[] cIDtmp = query2.ToArray();


                    var query3 = from a in db.Classes
                                 where a.Loc.Equals(location) &&
                                 ((DateTime.Compare(DateTime.Parse(a.Start.ToString()), start) >= 0 && DateTime.Compare(DateTime.Parse(a.Start.ToString()), end) <= 0) ||
                                 (DateTime.Compare(DateTime.Parse(a.Start.ToString()), start) <= 0 && DateTime.Compare(DateTime.Parse(a.Start.ToString()), end) >= 0) ||
                                 (DateTime.Compare(DateTime.Parse(a.Start.ToString()), start) <= 0 && DateTime.Compare(DateTime.Parse(a.End.ToString()), end) >= 0))
                                 select a.CId;

                    if (query3.Any())
                    {
                        return Json(new { success = false });
                    }
                    else
                    {
                        var query = from a in db.Classes
                                    select a.ClsId;

                        bool cond = true;
                        string s = string.Empty;
                        while (true)
                        {
                            var random = new Random();
                            s = "";
                            for (int i = 0; i < 3; i++)
                                s = String.Concat(s, random.Next(10).ToString());

                            foreach (int U in query)
                            {
                                if (U.ToString().Equals(s))
                                {
                                    cond = false;
                                }
                            }
                            if (cond)
                            {
                                break;
                            }

                        }

                        Classes newCls = new Classes();
                        newCls.Year = (uint?)year;
                        newCls.CId = cIDtmp[0];
                        newCls.PId = instructor;
                        newCls.ClsId = Int32.Parse(s);
                        newCls.Loc = location;
                        newCls.Start = new TimeSpan(start.Hour, start.Minute, start.Second);
                        newCls.End = new TimeSpan(end.Hour, end.Minute, end.Second);
                        newCls.Season = season;
                        db.Classes.Add(newCls);
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                }
                catch (Exception)
                {
                    return Json(new { success = false });
                }
            }

        }


        /*******End code to modify********/

    }
}