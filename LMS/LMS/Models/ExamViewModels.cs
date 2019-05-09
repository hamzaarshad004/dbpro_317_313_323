using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class ExamViewModel
    {
        [Required]
        public int ExamId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class ExamSubjectsViewModel
    {
        [Required]
        public int ExamId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int TotalMarks { get; set; }
        [Required]
        public System.DateTime StartDateTime { get; set; }
        [Required]
        public System.DateTime EndTime { get; set; }
        [Required]

        public string ExamName { get; set; }
        [Required]
        public string SubjectName { get; set; }
        
        public IEnumerable<Exam> ExamNames { get; set; }
        public IEnumerable<Subject> SubjectNames { get; set; }
    }

    public class ResultViewModel
    {
        [Required]
        public int ExamId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ObtainedMarks { get; set; }
        [Required]
        public string ExamName { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string StudentName { get; set; }

        public IEnumerable<Exam> ExamNames { get; set; }
        public IEnumerable<Subject> SubjectNames { get; set; }
    }
}