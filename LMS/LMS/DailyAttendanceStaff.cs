//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyAttendanceStaff
    {
        public int DateId { get; set; }
        public int StaffId { get; set; }
        public string AttendanceStatus { get; set; }
    
        public virtual DateKeeper DateKeeper { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
