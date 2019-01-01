using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<StudentCourseCollection> StudentCourseCollections { get; set; }
    }
}