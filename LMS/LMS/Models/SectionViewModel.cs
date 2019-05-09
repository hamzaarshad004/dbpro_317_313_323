using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SectionViewModel
    {
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }
        [Required]
        public int Batch { get; set; }
        [Required]
        public int TotalStudents { get; set; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }

        public IEnumerable<Program> ProgramsList { get; set; }
    }
}

