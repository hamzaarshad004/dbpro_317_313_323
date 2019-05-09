using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class TimeTableViewModel
    {
        [Required]
        public int timetableId { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public System.DateTime StartTime { get; set; }
        [Required]
        public System.DateTime EndTime { get; set; }
        [Required]
        public IEnumerable<Section> allSection { get; set; }
        public IEnumerable<Subject> allSubject { get; set; }
    }
}