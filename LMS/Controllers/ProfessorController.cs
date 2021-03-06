using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Models.LMSModels;

namespace LMS.Controllers
{
  [Authorize(Roles = "Professor")]
  public class ProfessorController : CommonController
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Students(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
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

    public IActionResult Categories(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
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

    public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      return View();
    }

    public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      ViewData["uid"] = uid;
      return View();
    }

    /*******Begin code to modify********/


    /// <summary>
    /// Returns a JSON array of all the students in a class.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "dob" - date of birth
    /// "grade" - the student's grade in this class
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from u in db.Users
                            join stu in db.Students on u.UId equals stu.UId
                            join e in db.Enrolled on stu.UId equals e.UId
                            join cl in db.Classes on e.ClsId equals cl.ClsId
                            join co in db.Courses on cl.CId equals co.CId
                            where co.Subject == subject && co.Num == num &&
                                  cl.Season == season && cl.Year == year
                            select new
                            {
                                fname = u.FName,
                                lname = u.LName,
                                uid = u.UId,
                                dob = u.Dob,
                                grade = e.Grade
                            };
                return Json(query.ToArray());

            }
        }



    /// <summary>
    /// Returns a JSON array with all the assignments in an assignment category for a class.
    /// If the "category" parameter is null, return all assignments in the class.
    /// Each object in the array should have the following fields:
    /// "aname" - The assignment name
    /// "cname" - The assignment category name.
    /// "due" - The due DateTime
    /// "submissions" - The number of submissions to the assignment
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class, 
    /// or null to return assignments from all categories</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                if (category == null)
                {
                    var query = from co in db.Courses
                                join cl in db.Classes on co.CId equals cl.CId
                                join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                                join an in db.Assignments on ac.AcId equals an.AcId
                                where co.Subject == subject && co.Num == num &&
                                      cl.Season == season && cl.Year == year
                                select new
                                {
                                    aname = an.Name,
                                    cname = ac.Name,
                                    due = an.Due,
                                    submissions = (from su in db.Submissions
                                                   join a in db.Assignments on su.AId equals a.AId
                                                   where a.Name == an.Name
                                                   select su.UId).Count()
                                };
                    return Json(query.ToArray());
                }
                else
                {
                    var query = from co in db.Courses
                                join cl in db.Classes on co.CId equals cl.CId
                                join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                                join an in db.Assignments on ac.AcId equals an.AcId
                                where co.Subject == subject && co.Num == num &&
                                      cl.Season == season && cl.Year == year &&
                                      ac.Name == category
                                select new
                                {
                                    aname = an.Name,
                                    cname = ac.Name,
                                    due = an.Due,
                                    submissions = (from su in db.Submissions
                                                   join a in db.Assignments on su.AId equals a.AId
                                                   where a.Name == an.Name
                                                   select su.UId).Count()
                                };
                    return Json(query.ToArray());
                }
            }
        }


    /// <summary>
    /// Returns a JSON array of the assignment categories for a certain class.
    /// Each object in the array should have the folling fields:
    /// "name" - The category name
    /// "weight" - The category weight
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                            where co.Subject == subject && co.Num == num &&
                                  cl.Season == season && cl.Year == year
                            select new
                            {
                                name = ac.Name,
                                weight = ac.Weight
                            };
                return Json(query.ToArray());
            }
        }

    /// <summary>
    /// Creates a new assignment category for the specified class.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The new category name</param>
    /// <param name="catweight">The new category weight</param>
    /// <returns>A JSON object containing {success = true/false},
    ///	false if an assignment category with the same name already exists in the same class.</returns>
    public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                try
                {
                    var query0 = from b in db.Courses
                                 where b.Subject.Equals(subject) && b.Num.Equals(num)
                                 join i in db.Classes on b.CId equals i.CId into inv
                                 from j1 in inv.DefaultIfEmpty()
                                 where j1.Year == year && j1.Season.Equals(season)
                                 join i2 in db.AssignmentCategories on j1.ClsId equals i2.ClsId into inv2
                                 from j2 in inv2.DefaultIfEmpty()
                                 where j2.Name.Equals(category)
                                 select j2;


                    var query2 = from b in db.Courses
                                 where b.Subject.Equals(subject) && b.Num.Equals(num)
                                 join i in db.Classes on b.CId equals i.CId into inv
                                 from j1 in inv.DefaultIfEmpty()
                                 where j1.Year == year && j1.Season.Equals(season)
                                 select j1.ClsId;
                    int[] clsIDtmp = query2.ToArray();

                    if (query0.Any())
                    {
                        return Json(new { success = false });
                    }
                    else
                    {
                        var query = from a in db.AssignmentCategories
                                    select a.AcId;

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

                        AssignmentCategories newAC = new AssignmentCategories();
                        newAC.AcId = Int32.Parse(s);
                        newAC.ClsId = clsIDtmp[0];
                        newAC.Name = category;
                        newAC.Weight = (uint)catweight;
                        db.AssignmentCategories.Add(newAC);
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
    /// Creates a new assignment for the given class and category.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="asgpoints">The max point value for the new assignment</param>
    /// <param name="asgdue">The due DateTime for the new assignment</param>
    /// <param name="asgcontents">The contents of the new assignment</param>
    /// <returns>A JSON object containing success = true/false,
	/// false if an assignment with the same name already exists in the same assignment category.</returns>
    public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                try
                {
                    var query0 = from b in db.Courses
                                 where b.Subject.Equals(subject) && b.Num.Equals(num)
                                 join i in db.Classes on b.CId equals i.CId into inv
                                 from j1 in inv.DefaultIfEmpty()
                                 where j1.Year == year && j1.Season.Equals(season)
                                 join i2 in db.AssignmentCategories on j1.ClsId equals i2.ClsId into inv2
                                 from j2 in inv2.DefaultIfEmpty()
                                 where j2.Name.Equals(category)
                                 join i3 in db.Assignments on j2.AcId equals i3.AcId into inv3
                                 from j3 in inv3.DefaultIfEmpty()
                                 where j3.Name.Equals(asgname)
                                 select j3;


                    var query2 = from b in db.Courses
                                 where b.Subject.Equals(subject) && b.Num.Equals(num)
                                 join i in db.Classes on b.CId equals i.CId into inv
                                 from j1 in inv.DefaultIfEmpty()
                                 where j1.Year == year && j1.Season.Equals(season)
                                 join i2 in db.AssignmentCategories on j1.ClsId equals i2.ClsId into inv2
                                 from j2 in inv2.DefaultIfEmpty()
                                 where j2.Name.Equals(category)
                                 select j2.AcId;


                    int[] acIDtmp = query2.ToArray();

                    if (query0.Any())
                    {
                        return Json(new { success = false });
                    }
                    else
                    {
                        var query = from a in db.Assignments
                                    select a.AId;

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

                        Assignments newA = new Assignments();
                        newA.AId = Int32.Parse(s);
                        newA.AcId = acIDtmp[0];
                        newA.Name = asgname;
                        newA.Contents = asgcontents;
                        newA.Due = asgdue;
                        newA.Points = asgpoints;

                        db.Assignments.Add(newA);
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
    /// Gets a JSON array of all the submissions to a certain assignment.
    /// Each object in the array should have the following fields:
    /// "fname" - first name
    /// "lname" - last name
    /// "uid" - user ID
    /// "time" - DateTime of the submission
    /// "score" - The score given to the submission
    /// 
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                            join an in db.Assignments on ac.AcId equals an.AcId
                            join su in db.Submissions on an.AId equals su.AId
                            join stu in db.Students on su.UId equals stu.UId
                            join u in db.Users on stu.UId equals u.UId
                            where co.Subject == subject && co.Num == num &&
                                  cl.Season == season && cl.Year == year &&
                                  ac.Name == category && an.Name == asgname
                            select new
                            {
                                fname = u.FName,
                                lname = u.LName,
                                uid = u.UId,
                                time = su.Time,
                                score = su.Score
                            };

                return Json(query.ToArray());
            }
        }


    /// <summary>
    /// Set the score of an assignment submission
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The name of the assignment</param>
    /// <param name="uid">The uid of the student who's submission is being graded</param>
    /// <param name="score">The new score for the submission</param>
    /// <returns>A JSON object containing success = true/false</returns>
    public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                try { 
                var query2 = from co in db.Courses
                             join cl in db.Classes on co.CId equals cl.CId
                             join ac in db.AssignmentCategories on cl.ClsId equals ac.ClsId
                             join an in db.Assignments on ac.AcId equals an.AcId
                             join su in db.Submissions on an.AId equals su.AId
                             where co.Subject == subject && co.Num == num &&
                                  cl.Season == season && cl.Year == year &&
                                  ac.Name == category && an.Name == asgname &&
                                  su.UId.Equals(uid)
                             select su;

                foreach (Submissions S in query2)
                {
                    if (S.UId.Equals(uid))
                    {
                        S.Score = (uint)score;
                    }
                }
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                catch { return Json(new { success = false }); }

            }
        }


    /// <summary>
    /// Returns a JSON array of the classes taught by the specified professor
    /// Each object in the array should have the following fields:
    /// "subject" - The subject abbreviation of the class (such as "CS")
    /// "number" - The course number (such as 5530)
    /// "name" - The course name
    /// "season" - The season part of the semester in which the class is taught
    /// "year" - The year part of the semester in which the class is taught
    /// </summary>
    /// <param name="uid">The professor's uid</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetMyClasses(string uid)
    {
            using (Team6LMSContext db = new Team6LMSContext())
            {
                var query = from co in db.Courses
                            join cl in db.Classes on co.CId equals cl.CId
                            where cl.PId == uid
                            select new
                            {
                                subject = co.Subject,
                                number = co.Num,
                                name = co.Name,
                                season = cl.Season,
                                year = cl.Year
                            };

                return Json(query.ToArray());
            }
        }


    /*******End code to modify********/

  }
}