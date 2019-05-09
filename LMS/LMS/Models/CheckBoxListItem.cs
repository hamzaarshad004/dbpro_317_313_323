using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class CheckBoxListItem
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Display { get; set; }
        [Required]
        public bool IsChecked { get; set; }
    }

    public class CheckBoxListItemStaff
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Display { get; set; }
        [Required]
        public string DisplayDesignation { get; set; }
        [Required]
        public bool IsChecked { get; set; }
    }
}