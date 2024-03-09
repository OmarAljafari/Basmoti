using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterService : BaseEntity
    {
        public int MasterServiceId { get; set; }
        [Display(Name = "Title")]
        public string? MasterServiceTitle { get; set; }
        [Display(Name = "Description")]
        public string? MasterServiceDesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterServiceImage { get; set; }
    }
}
