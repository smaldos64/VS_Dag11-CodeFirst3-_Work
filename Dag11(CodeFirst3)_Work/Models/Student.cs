using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class Student
    {
        public const string EMailFrom = "ltpe@techcollege.dk";

        private int _studentAge;

        //[Required]
        //[Range(1, 100)]
        public int StudentID { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        [Range(15, 65)]
        public int StudentAge
        {
            get
            {
                return (this._studentAge);
            }
            set
            {
                if ( (value >= 15) && (value <= 65) )
                {
                    this._studentAge = value;
                }
                else
                {
                    int Test = 10;
                }
            }
        }

        [Required]
        [EmailAddress]
        public string StudentEMailAddress { get; set; }

        [Required]
        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }

        public virtual ICollection<StudentCourseCollection> StudentCourseCollections { get; set; }

        // Metoder i klassen Point følger herunder !!!
        public static List<Student> GetStudentData()
        {
            List<Student> StudentList = new List<Student>();

            for (int Counter = 0; Counter < 10; Counter++)
            {
                Student ThisStudent = new Student();

                ThisStudent.StudentAge = Counter + 15;
                ThisStudent.StudentName = "Hans " + Counter.ToString();
                ThisStudent.StudentID = (Counter + 1);
                StudentList.Add(ThisStudent);
            }

            return (StudentList);
        }

        // Klassen skal override Equals metoden for at distinct virker på klassen.
        // Og dermed at man kan fjerne dubletter !!!
        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return (false);
            }
            else
            {
                var other = obj as Student;
                return ((this.StudentID == other.StudentID));
            }
        }
        
        // Klassen skal override GetHashCode metoden for at distinct virker på klassen.
        // Og dermed at man kan fjerne dubletter !!!
        public override int GetHashCode()
        {
            return (this.StudentID);
        }
    }
}