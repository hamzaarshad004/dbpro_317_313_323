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
        public int PersonId;
        public string Name { get; set; }
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }

        public int StaffId;
        public string Designation { get; set; }
        public System.DateTime HireDate { get; set; }
        public double MonthlySalary { get; set; }

        
    }

    public class StaffAttendanceModel
    {
        public System.DateTime SelectedDate { get; set; }
        public List<CheckBoxListItemStaff> Staffs { get; set; }

        public StaffAttendanceModel()
        {
            Staffs = new List<CheckBoxListItemStaff>();
        }
    }
}