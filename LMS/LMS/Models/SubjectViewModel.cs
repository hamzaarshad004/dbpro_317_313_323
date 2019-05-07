using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SubjectViewModel
    {
        public int ProgramId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public IEnumerable<Program> allPrograms { get; set; }

        public class ShowAllsubjects
        {
            public List<Subject> allsubjects { get; set; }
        }
    }
}