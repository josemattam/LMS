using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Enrolled
    {
        public string UId { get; set; }
        public int ClsId { get; set; }
        public string Grade { get; set; }

        public virtual Classes Cls { get; set; }
        public virtual Students U { get; set; }
    }
}
