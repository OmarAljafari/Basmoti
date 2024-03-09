using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterItemMenuViewModel:BaseModel
    {
        public int MasterItemMenuId { get; set; }
        [Display(Name = "Category of item")]
        public int? MasterCategoryMenuId { get; set; }
        [Display(Name ="Title")]
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
        [Display(Name ="Upload Image")]
        public IFormFile? file { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
    }
}
