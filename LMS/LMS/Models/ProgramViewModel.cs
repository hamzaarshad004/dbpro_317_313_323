using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class ProgramViewModel
    {
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public System.DateTime AdmissionStart { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime AdmissionEnd { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime ClassesStart { get; set; }
        

        public class ShowAllPrograms
        {
            public List<Program> allprograms { get; set; }
        }
    }
}