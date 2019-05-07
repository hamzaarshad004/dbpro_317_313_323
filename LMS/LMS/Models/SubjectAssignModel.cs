using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SubjectAssignModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ProgramId { get; set; }
        public IEnumerable<Subject> allsubjects { get; set; }
    }
    public class CourseTeacherViewModel
    {
        public int StaffId { get; set; }
        public int SubjectId { get; set; }
        public string Designation { get; set; }
        public IEnumerable<Subject> allsubjects { get; set; }
    }
}