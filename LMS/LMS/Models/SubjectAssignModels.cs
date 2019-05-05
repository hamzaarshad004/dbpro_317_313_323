using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class StudentSubjectViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }

    public class CourseTeacherViewModel
    {
        public int StaffId { get; set; }
        public int SubjectId { get; set; }
    }
}
