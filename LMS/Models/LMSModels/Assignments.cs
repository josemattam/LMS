using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Assignments
    {
        public Assignments()
        {
            Submissions = new HashSet<Submissions>();
        }

        public int AId { get; set; }
        public int AcId { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
        public DateTime Due { get; set; }
        public float Points { get; set; }

        public virtual AssignmentCategories Ac { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}
