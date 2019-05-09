using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SubjectAssignModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ProgramId { get; set; }
        public IEnumerable<Subject> allsubjects { get; set; }
    }
    public class CourseTeacherViewModel
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string Designation { get; set; }
        public IEnumerable<Subject> allsubjects { get; set; }
    }
}