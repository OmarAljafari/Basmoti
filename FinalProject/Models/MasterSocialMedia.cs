using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterSocialMedia : BaseEntity
    {
        public int MasterSocialMediaId { get; set; }
        [Display(Name = "Image")]
        public string MasterSocialMediaImageUrl { get; set; } = null!;
        [Display(Name = "URL")]
        public string MasterSocialMediaUrl { get; set; } = null!;
    }
}
