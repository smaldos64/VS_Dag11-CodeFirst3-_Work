using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class CharacterWork
    {
        public int CharacterWorkID { get; set; }

        public string CharacterValue { get; set; }

        public virtual ICollection<StudentCourseCollection> StudentCourseCollections { get; set; }
    }
}