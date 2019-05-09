using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class DateKeeperViewModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Today's Date: ")]
        [Required]
        public System.DateTime CurrentDate { get; set; }
    }
}