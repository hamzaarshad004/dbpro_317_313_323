using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class TimeTableViewModel
    {
        public int timetableId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public string Day { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public IEnumerable<Section> allSection { get; set; }
        public IEnumerable<Subject> allSubject { get; set; }
    }
}