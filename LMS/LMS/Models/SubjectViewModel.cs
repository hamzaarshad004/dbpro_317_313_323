using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SubjectViewModel
    {
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public IEnumerable<Program> allPrograms { get; set; }

        public class ShowAllsubjects
        {
            public List<Subject> allsubjects { get; set; }
        }
    }
}