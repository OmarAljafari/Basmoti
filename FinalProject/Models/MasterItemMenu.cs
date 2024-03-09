using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterItemMenu : BaseEntity
    {
        public int MasterItemMenuId { get; set; }
        [Display(Name = "Category of item")]
        public int? MasterCategoryMenuId { get; set; }
        [Display(Name = "Title")]
        public string? MasterItemMenuTitle { get; set; }
        [Display(Name = "Breef")]
        public string? MasterItemMenuBreef { get; set; }
        [Display(Name = "Description")]
        public string? MasterItemMenuDesc { get; set; }
        [Display(Name = "Price")]
        public decimal? MasterItemMenuPrice { get; set; }
        [Display(Name = "Image")]
        public string? MasterItemMenuImageUrl { get; set; }
        [Display(Name = "Date")]
        public DateTime? MasterItemMenuDate { get; set; }
        [Display(Name ="URL")]
        public string MasterItemUrl { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
    }
}
