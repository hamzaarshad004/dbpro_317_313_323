using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Models
{
    public class StaffViewModel
    {
        [Required]
        public int PersonId;
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        [Required]
        public string Cnic { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }
        [Required]
        public int StaffId;
        [Required]
        public string Designation { get; set; }
        [Required]
        public System.DateTime HireDate { get; set; }
        [Required]
        public double MonthlySalary { get; set; }

        

        
    }
    public class SubjectList
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StaffId;

        [DisplayName("Subjects: ")]
        public IEnumerable<Subject> Subjects { get; set; }
    }
    public class StaffAttendanceModel
    {
        [Required]
        public System.DateTime SelectedDate { get; set; }
        public List<CheckBoxListItemStaff> Staffs { get; set; }

        public StaffAttendanceModel()
        {
            Staffs = new List<CheckBoxListItemStaff>();
        }
    }
}