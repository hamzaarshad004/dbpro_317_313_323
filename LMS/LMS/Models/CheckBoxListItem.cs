using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class CheckBoxListItem
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }

    public class CheckBoxListItemStaff
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public string DisplayDesignation { get; set; }
        public bool IsChecked { get; set; }
    }
}