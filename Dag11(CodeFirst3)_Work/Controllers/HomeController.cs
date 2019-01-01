using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dag11_CodeFirst3__Work.Models;

namespace Dag11_CodeFirst3__Work.Controllers
{
    public class HomeController : Controller
    {
        private CodeModelDB db = new CodeModelDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Student
        public ActionResult StudentList()
        {
            List<Student> Student_ObjectList = db.Students.ToList();

            return View(Student_ObjectList);
        }
        #endregion
              
        #region Team
        public ActionResult TeamList()
        {
            List<Team> Team_ObjectList = db.Teams.ToList();

            return View(Team_ObjectList);
        }
        #endregion

        #region Course
        public ActionResult CourseList()
        {
            List<Course> Course_ObjectList = db.Courses.ToList();

            return (View(Course_ObjectList));
        }
        #endregion
    }
}