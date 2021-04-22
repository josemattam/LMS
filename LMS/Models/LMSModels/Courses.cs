﻿using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Courses
    {
        public Courses()
        {
            Classes = new HashSet<Classes>();
        }

        public int CId { get; set; }
        public int Num { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public virtual Departments SubjectNavigation { get; set; }
        public virtual ICollection<Classes> Classes { get; set; }
    }
}
