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
    
    public partial class MonthlyReport
    {
        public int MonthId { get; set; }
        public double Expenses { get; set; }
        public double Revenue { get; set; }
    
        public virtual CalenderMonth CalenderMonth { get; set; }
    }
}
