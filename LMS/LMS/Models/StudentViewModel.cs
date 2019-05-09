using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace LMS.Models
{
    public class StudentViewModel
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }

        [Required]
        public string Cnic { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNo { get; set; }

        [Required]
        public int StudentId { get; set; }
        public int Batch { get; set; }
        [Required]
        [Remote("CheckRollNoExists", "Student", ErrorMessage = "Roll no already alloted")]
        public string RollNo { get; set; }
        [Required]
        public double MonthlyFee { get; set; }
        [Required]
        public System.DateTime AdmissionDate { get; set; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]

        [DisplayName("Degree Program")]
        public IEnumerable<Program> Programs { get; set; }

        public IEnumerable<Subject> allsubjects { get; set; }

        [Required]
        public int SectionAssigned { get; set; }


        public int checkAssigned(int id)
        {
            DB45Entities db = new DB45Entities();
            var S = db.Sections.ToList();
            var Student = db.Students.Where(c => c.StudentId == id).First();
            int check = 0;
            foreach( var sec in S)
            {
                if (sec.Students.Contains(Student))
                {
                    check = 1;
                    break;
                }
                else
                {

                }
            }
            return check;
        }

    }

    public class SectionsList
    {
        public int SectionId { get; set; }

        [DisplayName("Section: ")]
        public IEnumerable<Section> Sections { get; set; }
    }

    public class StudentAttendanceModel
    {
        public System.DateTime SelectedDate { get; set; }
        public List<CheckBoxListItem> Students { get; set; }

        public StudentAttendanceModel()
        {
            Students = new List<CheckBoxListItem>();
        }
    }

    public class StudentAttendanceReportModel
    {
        [Required]
        public System.DateTime Date { get; set; }
    
        public string AttendanceStatus { get; set; }
       
        public string RollNo { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
