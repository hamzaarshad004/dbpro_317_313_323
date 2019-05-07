using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
    }

    public class ExamSubjectsViewModel
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public int TotalMarks { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndTime { get; set; }

        public string ExamName { get; set; }
        public string SubjectName { get; set; }

        public IEnumerable<Exam> ExamNames { get; set; }
        public IEnumerable<Subject> SubjectNames { get; set; }
    }

    public class ResultViewModel
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int ObtainedMarks { get; set; }

        public string ExamName { get; set; }
        public string SubjectName { get; set; }
        public string StudentName { get; set; }

        public IEnumerable<Exam> ExamNames { get; set; }
        public IEnumerable<Subject> SubjectNames { get; set; }
    }
}