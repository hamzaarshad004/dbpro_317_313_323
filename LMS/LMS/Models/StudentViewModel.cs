using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Models
{
    public class StudentViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        public int StudentId { get; set; }
        public int Batch { get; set; }
        public string RollNo { get; set; }
        public double MonthlyFee { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        public int ProgramId { get; set; }
        public int SubjectId { get; set; }

        [DisplayName("Degree Program")]
        public IEnumerable<Program> Programs { get; set; }

        public IEnumerable<Subject> allsubjects { get; set; }

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
}
