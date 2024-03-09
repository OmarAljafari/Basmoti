using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterSlider : BaseEntity
    {
        public int MasterSliderId { get; set; }
        [Display(Name ="Title")]
        public string? MasterSliderTitle { get; set; }
        [Display(Name = "Breef")]
        public string? MasterSliderBreef { get; set; }
        [Display(Name = "Description")]
        public string? MasterSliderDesc { get; set; }
        [Display(Name = "URL")]
        public string? MasterSliderImg { get; set; }
    }
}
