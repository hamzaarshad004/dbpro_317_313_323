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

        [DisplayName("Degree Program")]
        public IEnumerable<Program> Programs { get; set; }
    }
}