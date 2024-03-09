using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterWorkingHour : BaseEntity
    {
        public int MasterWorkingHourId { get; set; }
        [Display(Name ="Name")]
        public string? MasterWorkingHourIdName { get; set; }
        [Display(Name = "Form")]
        public string? MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
