using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterContactUsInformation : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }
        [Display(Name ="Description")]
        public string? MasterContactUsInformationIdesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterContactUsInformationImageUrl { get; set; }
        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }
    }
}
