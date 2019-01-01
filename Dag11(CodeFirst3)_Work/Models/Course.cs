using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public virtual ICollection<StudentCourseCollection> StudentCourseCollections { get; set; }
    }
}