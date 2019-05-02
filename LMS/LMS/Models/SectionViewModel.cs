using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SectionViewModel
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int Batch { get; set; }
        public int TotalStudents { get; set; }
    }
}

