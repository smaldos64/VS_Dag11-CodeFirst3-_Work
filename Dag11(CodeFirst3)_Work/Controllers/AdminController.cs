using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dag11_CodeFirst3__Work.Models;

namespace Dag11_CodeFirst3__Work.Controllers
{
    public class AdminController : Controller
    {
        private CodeModelDB db = new CodeModelDB();

        // GET: Admin
        public ActionResult Index()
        {
            List<Character> CharacterList = Character.GetCharacters();
            return View();
        }

        #region Student
        public ActionResult CreateStudent()
        {
            List<Team> TeamList = db.Teams.ToList();

            return View(TeamList);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student Student_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                Student_Object.StudentName =
                    StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Student_Object.StudentName, ' ');

                db.Students.Add(Student_Object);
                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("StudentList", "Home"));
                }
                else
                {
                    return (RedirectToAction("Index", "Home"));
                }
            }
            else
            {
                return (View());
            }
        }

        public ActionResult DeleteStudent(int Id)
        {
            Student Student_Object = db.Students.Find(Id);
            if (null != Student_Object)
            {
                db.Students.Remove(Student_Object);
                db.SaveChanges();
            }

            return (RedirectToAction("StudentList", "Home"));
        }

        public ActionResult EditStudent(int Id)
        {
            // De to udtryk herunder finder begge den adspurgte Student ud fra 
            // Studentens StudentId. Her repræsenteret ved variablen Id !!!
            //Student Student_Object1 = db.Students.FirstOrDefault(s => s.StudentID == Id);
            Student Student_Object = db.Students.Find(Id);
            ViewBag.TeamList = db.Teams.ToList();

            return (View(Student_Object));
        }

        [HttpPost]
        public ActionResult EditStudent(Student Student_Object)
        {
            int NumberOfRecordsSaved = 0;

            Student Student_ObjectSave = db.Students.Find(Student_Object.StudentID);
            Student_ObjectSave.TeamID = Student_Object.TeamID;
            Student_ObjectSave.StudentName = StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Student_Object.StudentName, ' ');
            Student_ObjectSave.StudentAge = Student_Object.StudentAge;
            Student_ObjectSave.StudentEMailAddress = Student_Object.StudentEMailAddress;

            NumberOfRecordsSaved = db.SaveChanges();

            if (NumberOfRecordsSaved > 0)
            {
                return (RedirectToAction("StudentList", "Home"));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        public ActionResult StudentDetails(int Id)
        {
            Student Student_Object = db.Students.Find(Id);

            if (null != Student_Object)
            {
                return (View(Student_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        public ActionResult StudentCourseDetails(int Id)
        {
            StudentCourseCollection StudentCourseCollection_Object = db.StudentCourseCollections.Find(Id);

            if (null != StudentCourseCollection_Object)
            {
                return (View(StudentCourseCollection_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }
        #endregion

        #region Team
        public ActionResult CreateTeam()
        {
            return (View());
        }

        [HttpPost]
        public ActionResult CreateTeam(Team Team_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                Team_Object.TeamName =
                    StringHandlingTools.ToUpperCaseAndRemoveUnwantedCharacters(Team_Object.TeamName);

                db.Teams.Add(Team_Object);
                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("TeamList", "Home"));
                }
                else
                {
                    return (RedirectToAction("Index", "Admin"));
                }
            }
            else
            {
                return (View());
            }
        }

        public ActionResult EditTeam(int Id)
        {
            Team Team_Object = db.Teams.Find(Id);

            if (null != Team_Object)
            {
                return (View(Team_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Admin"));
            }
        }

        [HttpPost]
        public ActionResult EditTeam(Team Team_Object)
        {
            int NumberOfRecordsSaved = 0;

            Team Team_ObjectSave = db.Teams.Find(Team_Object.TeamID);
            Team_ObjectSave.TeamID = Team_Object.TeamID;
            Team_ObjectSave.TeamName = StringHandlingTools.ToUpperCaseAndRemoveUnwantedCharacters(Team_Object.TeamName);

            NumberOfRecordsSaved = db.SaveChanges();

            if (NumberOfRecordsSaved > 0)
            {
                return (RedirectToAction("TeamList", "Home"));
            }
            else
            {
                return (RedirectToAction("Index", "Admin"));
            }
        }

        public ActionResult DeleteTeam(int Id)
        {
            Team Team_Object = db.Teams.Find(Id);

            if (null != Team_Object)
            {
                List<Student> Student_ObjectList = db.Students.Where(s => s.TeamID == Id).ToList();

                foreach (Student item in Student_ObjectList)
                {
                    db.Students.Remove(item);
                }
                db.SaveChanges();

                List<StudentCourseCollection> StudentCourseCollection_ObjectList =
                    db.StudentCourseCollections.Where(s => s.TeamID == Id).ToList();

                foreach (StudentCourseCollection item in StudentCourseCollection_ObjectList)
                {
                    db.StudentCourseCollections.Remove(item);
                }
                db.SaveChanges();
                
                db.Teams.Remove(Team_Object);
                db.SaveChanges();
            }

            return (RedirectToAction("TeamList", "Home"));
        }

        public ActionResult TeamDetails(int Id)
        {
            Team Team_Object = db.Teams.Find(Id);

            if (null != Team_Object)
            {
                ViewBag.StudentList = db.Students.Where(s => s.TeamID == Id).ToList();
                return (View(Team_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Admin"));
            }
        }
        #endregion

        #region Course
        public ActionResult CreateCourse()
        {
            return (View());
        }

        [HttpPost]
        public ActionResult CreateCourse(Course Course_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                Course_Object.CourseName =
                    StringHandlingTools.FirstToUpperCaseAndRemoveUnwantedCharacters(Course_Object.CourseName);

                db.Courses.Add(Course_Object);
                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("CourseList", "Home"));
                }
                else
                {
                    return (RedirectToAction("Index", "Admin"));
                }
            }
            else
            {
                return (View());
            }
        }

        public ActionResult CourseDetails(int Id)
        {
            // I koden herunder vises 3 forskellige metoder til at få oprettet en liste af 
            // studerende, der er koblet på et givet fag.
            
            // Metode 1 
            List<StudentCourseCollection> StudentCourseCollection_ObjectList = db.StudentCourseCollections.Where(c => c.CourseID == Id).ToList();
            List<Student> Student_ObjectList = new List<Student>();

            foreach (StudentCourseCollection item in StudentCourseCollection_ObjectList)
            {
                Student Student_Object = db.Students.Find(item.StudentID);
                Student_ObjectList.Add(Student_Object);
            }
            Student_ObjectList = Student_ObjectList.Distinct().ToList();
            // Slut på Metode 1

            // Metode 2
            var Student_ObjectList1 = db.Students.SelectMany(s => s.StudentCourseCollections).Where(c => c.CourseID == Id).ToList();
            // Slut på Metode 2

            // Metode 3
            List<Student> Student_ObjectList2 = db.Students.Where(s => s.StudentCourseCollections.Any(c => c.CourseID == Id)).ToList();
            Student_ObjectList2 = Student_ObjectList2.Distinct().ToList();
            // Slut på Metode 3

            // Find den sidste afgivne karakter for alle studerende koblet til det specifikke
            // Fag.
            List<string> CharacterValueList = new List<string>();
            foreach (Student item in Student_ObjectList2)
            {
                //string CharacterValue = item.StudentCourseCollections.Any(c => c.CourseID == Id).ToString();
                string CharacterValue = item.StudentCourseCollections.Where(c => c.CourseID == Id).Last().CharacterWork.CharacterValue;
                CharacterValueList.Add(CharacterValue);
            }

            ViewBag.CourseName = db.Courses.Find(Id).CourseName;
            ViewBag.CharacterValueList = CharacterValueList;
            return View(Student_ObjectList2);
        }

        public ActionResult EditCourse(int Id)
        {
            Course Courese_Object = db.Courses.Find(Id);

            if (null != Courese_Object)
            {
                return (View(Courese_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Admin"));
            }
        }

        [HttpPost]
        public ActionResult EditCourse(Course Course_Object)
        {
            int NumberOfRecordsSaved = 0;

            Course Course_ObjectSave = db.Courses.Find(Course_Object.CourseID);
            Course_ObjectSave.CourseID = Course_Object.CourseID;
            Course_ObjectSave.CourseName = StringHandlingTools.FirstToUpperCaseAndRemoveUnwantedCharacters(Course_Object.CourseName);

            NumberOfRecordsSaved = db.SaveChanges();

            if (NumberOfRecordsSaved > 0)
            {
                return (RedirectToAction("CourseList", "Home"));
            }
            else
            {
                return (RedirectToAction("Index", "Admin"));
            }
        }

        public ActionResult DeleteCourse(int Id)
        {
            Course Course_Object = db.Courses.Find(Id);

            if (null != Course_Object)
            {
                db.Courses.Remove(Course_Object);
                db.SaveChanges();
            }

            return (RedirectToAction("CourseList", "Home"));
        }
        #endregion

        #region Character
        public ActionResult ApplyCharacter(int Id)
        {
            ViewBag.CourseList = db.Courses.ToList();
            ViewBag.CharacterWorkList = db.CharacterWorks.ToList();

            Student Student_Object = db.Students.Find(Id);

            return View(Student_Object);
        }

        [HttpPost]
        public ActionResult ApplyCharacter(StudentCourseCollection StudentCourseCollection_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                db.StudentCourseCollections.Add(StudentCourseCollection_Object);
                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("StudentDetails", "Admin", new { Id = StudentCourseCollection_Object.StudentID }));
                }
                else
                {
                    return (RedirectToAction("Index", "Home"));
                }
            }
            else
            {
                return (RedirectToAction("ApplyCharacter", "Admin", new { Id = StudentCourseCollection_Object.StudentID }));
            }
        }

        public ActionResult EditStudentCourseCharacter(int Id)
        {
            StudentCourseCollection StudentCourseCollection_Object =
                db.StudentCourseCollections.Find(Id);

            if (null != StudentCourseCollection_Object)
            {
                ViewBag.CourseList = db.Courses.ToList();
                ViewBag.CharacterWorkList = db.CharacterWorks.ToList();
                ViewBag.TeamList = db.Teams.ToList();

                return (View(StudentCourseCollection_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        [HttpPost]
        public ActionResult EditStudentCourseCharacter(StudentCourseCollection StudentCourseCollection_Object)
        {
            int NumberOfRecordsSaved = 0;
            StudentCourseCollection StudentCourseCollection_ObjectSave = db.StudentCourseCollections.Find(StudentCourseCollection_Object.StudentCourseCollectionID);

            if (null != StudentCourseCollection_ObjectSave)
            {
                StudentCourseCollection_ObjectSave.StudentID = StudentCourseCollection_Object.StudentID;
                StudentCourseCollection_ObjectSave.CourseID = StudentCourseCollection_Object.CourseID;
                StudentCourseCollection_ObjectSave.CharacterWorkID = StudentCourseCollection_Object.CharacterWorkID;
                StudentCourseCollection_ObjectSave.TeamID = StudentCourseCollection_Object.TeamID;
                StudentCourseCollection_ObjectSave.CourseComment = StudentCourseCollection_Object.CourseComment;

                NumberOfRecordsSaved = db.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("StudentDetails", "Admin", new { Id = StudentCourseCollection_Object.StudentID }));
                }
                else
                {
                    return (RedirectToAction("Index", "Home"));
                }
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        public ActionResult DeleteStudentCourseCharacter(int Id)
        {
            int StudentID = 0;
            StudentCourseCollection StudentCourseCollection_Object = db.StudentCourseCollections.Find(Id);

            if (null != StudentCourseCollection_Object)
            {
                StudentID = StudentCourseCollection_Object.StudentID;
                db.StudentCourseCollections.Remove(StudentCourseCollection_Object);
                db.SaveChanges();

                return (RedirectToAction("StudentDetails", "Admin", new { Id = StudentID }));
            }
            else
            {
                return (RedirectToAction("StudentList", "Home"));
            }
        }
        #endregion
                
        //#region Student
        //public ActionResult CreateStudent()
        //{
        //    List<Team> TeamList = db.Teams.ToList();

        //    return View(TeamList);
        //}

        //[HttpPost]
        //public ActionResult CreateStudent(Student Student_Object)
        //{
        //    int NumberOfRecordsSaved = 0;

        //    if (ModelState.IsValid)
        //    {
        //        Student_Object.StudentName =
        //            StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Student_Object.StudentName, ' ');

        //        db.Students.Add(Student_Object);
        //        NumberOfRecordsSaved = db.SaveChanges();

        //        if (NumberOfRecordsSaved > 0)
        //        {
        //            return (RedirectToAction("StudentList", "Home"));
        //        }
        //        else
        //        {
        //            return (RedirectToAction("Index", "Home"));
        //        }
        //    }
        //    else
        //    {
        //        return (View());
        //    }
        //}

        //public ActionResult DeleteStudent(int Id)
        //{
        //    Student Student_Object = db.Students.Find(Id);
        //    if (null != Student_Object)
        //    {
        //        db.Students.Remove(Student_Object);
        //        db.SaveChanges();
        //    }

        //    return (RedirectToAction("StudentList", "Home"));
        //}

        //public ActionResult EditStudent(int Id)
        //{
        //    // De to udtryk herunder finder begge den adspurgte Student ud fra 
        //    // Studentens StudentId. Her repræsenteret ved variablen Id !!!
        //    //Student Student_Object1 = db.Students.FirstOrDefault(s => s.StudentID == Id);
        //    Student Student_Object = db.Students.Find(Id);
        //    ViewBag.TeamList = db.Teams.ToList();

        //    return (View(Student_Object));
        //}

        //[HttpPost]
        //public ActionResult EditStudent(Student Student_Object)
        //{
        //    int NumberOfRecordsSaved = 0;

        //    Student Student_ObjectSave = db.Students.Find(Student_Object.StudentID);
        //    Student_ObjectSave.TeamID = Student_Object.TeamID;
        //    Student_ObjectSave.StudentName = StringHandlingTools.ToLowercaseAndSpecifiedCharacterToUpper(Student_Object.StudentName, ' ');
        //    Student_ObjectSave.StudentAge = Student_Object.StudentAge;
        //    Student_ObjectSave.StudentEMailAddress = Student_Object.StudentEMailAddress;

        //    NumberOfRecordsSaved = db.SaveChanges();

        //    if (NumberOfRecordsSaved > 0)
        //    {
        //        return (RedirectToAction("StudentList", "Home"));
        //    }
        //    else
        //    {
        //        return (RedirectToAction("Index", "Home"));
        //    }
        //}

        //public ActionResult StudentDetails(int Id)
        //{
        //    Student Student_Object = db.Students.Find(Id);

        //    if (null != Student_Object)
        //    {
        //        return (View(Student_Object));
        //    }
        //    else
        //    {
        //        return (RedirectToAction("Index", "Home"));
        //    }
        //}

        //public ActionResult StudentCourseDetails(int Id)
        //{
        //    StudentCourseCollection StudentCourseCollection_Object = db.StudentCourseCollections.Find(Id);

        //    if (null != StudentCourseCollection_Object)
        //    {
        //        return (View(StudentCourseCollection_Object));
        //    }
        //    else
        //    {
        //        return (RedirectToAction("Index", "Home"));
        //    }
        //}
        //#endregion

        #region Mail
        public ActionResult SendMail()
        {
            bool MailSendOk = true;

            List<Student> Student_ObjectList = db.Students.ToList();

            foreach (Student Student_Object in Student_ObjectList)
            {
                MailSendOk = MailHandlingTools.MailSender(Const.SMTP_ADDDRESS,
                                                          Student.EMailFrom,
                                                          Student_Object.StudentEMailAddress,
                                                          Const.MailSubject,
                                                          Const.MailMesage);
            }
            return (RedirectToAction("Index", "Home"));
        }
        #endregion
        
        #region TestCode
        public ActionResult Test()
        {
            int[] test = EnumHandlingTools.GetEnumValuesInt<CHARACTER_ENUM>();
            return View();
        }
        #endregion
    }
}