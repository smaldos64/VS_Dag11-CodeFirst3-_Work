using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class StudentCourseCollection
    {
        [Key, Column(Order = 0)]
        public int StudentCourseCollectionID { get; set; }

        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

        [Required]
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        [Required]
        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }

        public string CourseComment { get; set; }

        [Required]
        public int CharacterWorkID { get; set; }
        [ForeignKey("CharacterWorkID")]
        public virtual CharacterWork CharacterWork { get; set; }

        //[Required]
        //public int CharacterValue { get; set; }
    }
}