using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCategories = new HashSet<AssignmentCategories>();
            Enrolled = new HashSet<Enrolled>();
        }

        public int ClsId { get; set; }
        public uint? Year { get; set; }
        public int CId { get; set; }
        public string PId { get; set; }
        public string Loc { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Season { get; set; }

        public virtual Courses C { get; set; }
        public virtual Professors P { get; set; }
        public virtual ICollection<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual ICollection<Enrolled> Enrolled { get; set; }
    }
}
