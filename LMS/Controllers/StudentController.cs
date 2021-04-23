using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Models.LMSModels;
using Newtonsoft.Json;

namespace LMS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : CommonController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Class(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }


        public IActionResult ClassListings(string subject, string num)
        {
            System.Diagnostics.Debug.WriteLine(subject + num);
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }


        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of the classes the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester
        /// "year" - The year part of the semester
        /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            join e in db.Enrolled on cl.ClsId equals e.ClsId
                            join s in db.Students on e.UId equals s.UId
                            where s.UId == uid
                            select new
                            {
                                subject = co.Subject,
                                number = co.Num,
                                name = co.Name,
                                season = cl.Season,
                                year = cl.Year,
                                grade = e.Grade == null ? "--" : e.Grade
                                //Serial = j1 == null ? null : (uint?)j1.Serial,
                                //Name = j3 == null ? "" : j3.Name
                            };
                JsonResult jr = Json(query.ToArray());

                string str = JsonConvert.SerializeObject(jr.Value);

                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The category name that the assignment belongs to
        /// "due" - The due Date/Time
        /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="uid"></param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from t in db.Students
                            where t.UId.Equals("u1111111")
                            join i in db.Enrolled on t.UId equals i.UId into inv2
                            from j1 in inv2.DefaultIfEmpty()

                            join c in db.Classes on j1.ClsId equals c.ClsId into clsses2
                            from j4 in clsses2.DefaultIfEmpty()

                            join c1 in db.Courses on j4.CId equals c1.CId
                            where c1.Subject.Equals(subject) && c1.Num == num

                            join c2 in db.AssignmentCategories on j4.ClsId equals c2.ClsId into assgs
                            from j2 in assgs.DefaultIfEmpty()

                            join p in db.Assignments on j2.AcId equals p.AcId into pats2
                            from j3 in pats2.DefaultIfEmpty()

                            join p2 in db.Submissions on j3.AId equals p2.AId into pats3
                            from j5 in pats3.DefaultIfEmpty()

                            where j4.Year == year && j4.Season.Equals(season)
                            select new
                            {
                                aname = j3.Name,
                                cname = j2.Name,
                                due = j3.Due.ToString(),
                                score = j5 == null ? null : (float?)j5.Score
                            };
                return Json(query.ToArray());
            }
        }



        /// <summary>
        /// Adds a submission to the given assignment for the given student
        /// The submission should use the current time as its DateTime
        /// You can get the current time with DateTime.Now
        /// The score of the submission should start as 0 until a Professor grades it
        /// If a Student submits to an assignment again, it should replace the submission contents
        /// and the submission time (the score should remain the same).
        /// Does *not* automatically reject late submissions.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="uid">The student submitting the assignment</param>
        /// <param name="contents">The text contents of the student's submission</param>
        /// <returns>A JSON object containing {success = true/false}.</returns>
        public IActionResult SubmitAssignmentText(string subject, int num, string season, int year,
          string category, string asgname, string uid, string contents)
        {

            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query2 = from a in db.Assignments where a.Name.Equals(asgname) select a.AId;
                int[] AIDtmp = query2.ToArray();
                Submissions newSub = new Submissions();
                newSub.Contents = contents;
                newSub.Score = 0;
                newSub.UId = uid;
                newSub.AId = AIDtmp[0];
                newSub.Time = DateTime.Now;

                db.Submissions.Add(newSub);
                db.SaveChanges();
                return Json(new { success = true });
            }


        }


        /// <summary>
        /// Enrolls a student in a class.
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester</param>
        /// <param name="year">The year part of the semester</param>
        /// <param name="uid">The uid of the student</param>
        /// <returns>A JSON object containing {success = {true/false},
        /// false if the student is already enrolled in the Class.</returns>
        public IActionResult Enroll(string subject, int num, string season, int year, string uid)
        {

            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query2 = from a in db.Courses
                             where a.Subject.Equals(subject) && a.Num == num
                             join i in db.Classes on a.CId equals i.CId into inv2
                             from j1 in inv2.DefaultIfEmpty()
                             where j1.Year == year && j1.Season.Equals(season)
                             select j1.ClsId;

                int[] clsIDtmp = query2.ToArray();

                var query1 = from a in db.Enrolled
                             where a.UId.Equals(uid) && a.ClsId == clsIDtmp[0]
                             select a.UId;

                if (query1.ToString().Equals(uid))
                {
                    return Json(new { success = false });
                }
                else
                {
                    Enrolled newEnrl = new Enrolled();
                    newEnrl.UId = uid;
                    newEnrl.ClsId = clsIDtmp[0];
                    newEnrl.Grade = "";

                    db.Enrolled.Add(newEnrl);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
        }


        /// <summary>
        /// Calculates a student's GPA
        /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
        /// Assume all classes are 4 credit hours.
        /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
        /// If a student does not have any grades, they have a GPA of 0.0.
        /// Otherwise, the point-value of a letter grade is determined by the table on this page:
        /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
        public IActionResult GetGPA(string uid)
        {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query2 = from a in db.Enrolled
                             where a.UId.Equals("u1111111")
                             select a;
                int k = 0;
                double GPAtmp = 0;
                foreach (Enrolled E in query2)
                {
                    if (E.Grade.Equals("A") || E.Grade.Equals("A+"))
                    {
                        GPAtmp += 4;
                    }
                    else if (E.Grade.Equals("A-"))
                    {
                        GPAtmp += 3.7;
                    }
                    else if (E.Grade.Equals("B+"))
                    {
                        GPAtmp += 3.3;
                    }
                    else if (E.Grade.Equals("B"))
                    {
                        GPAtmp += 3.0;
                    }
                    else if (E.Grade.Equals("B-"))
                    {
                        GPAtmp += 2.7;
                    }
                    else if (E.Grade.Equals("C+"))
                    {
                        GPAtmp += 2.3;
                    }
                    else if (E.Grade.Equals("C"))
                    {
                        GPAtmp += 2.0;
                    }
                    else if (E.Grade.Equals("C-"))
                    {
                        GPAtmp += 1.7;
                    }
                    else if (E.Grade.Equals("D+"))
                    {
                        GPAtmp += 1.3;
                    }
                    else if (E.Grade.Equals("D"))
                    {
                        GPAtmp += 1.0;
                    }
                    else if (E.Grade.Equals("D-"))
                    {
                        GPAtmp += 0.7;
                    }
                    else if (E.Grade.Equals("E"))
                    {
                        GPAtmp += 0.0;
                    }
                    k += 1;
                };

                double GPA = GPAtmp / k;

                return Json(new { gpa = GPA });
            }
        }

        /*******End code to modify********/

    }
}