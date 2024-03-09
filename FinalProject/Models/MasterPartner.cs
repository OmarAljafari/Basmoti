using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterPartner : BaseEntity
    {
        public int MasterPartnerId { get; set; }
        [Display(Name = "Name")]
        public string? MasterPartnerName { get; set; }
        [Display(Name = "Image")]
        public string? MasterPartnerLogoImageUrl { get; set; }
        [Display(Name = "URL")]
        public string? MasterPartnerWebsiteUrl { get; set; }
    }
}
