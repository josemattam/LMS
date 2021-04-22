﻿using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class AssignmentCategories
    {
        public AssignmentCategories()
        {
            Assignments = new HashSet<Assignments>();
        }

        public int AcId { get; set; }
        public int ClsId { get; set; }
        public string Name { get; set; }
        public uint Weight { get; set; }

        public virtual Classes Cls { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}
