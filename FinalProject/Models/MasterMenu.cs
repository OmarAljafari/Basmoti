using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterMenu : BaseEntity
    {
        public int MasterMenuId { get; set; }
        [Display(Name ="Name of menu")]
        public string MasterMenuName { get; set; } = null!;
        [Display(Name = "URL")]
        public string MasterMenuUrl { get; set; } = null!;
    }
}
