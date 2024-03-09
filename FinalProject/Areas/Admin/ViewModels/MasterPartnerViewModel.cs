using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterPartnerViewModel : BaseModel
    {
        public int MasterPartnerId { get; set; }
        [Display(Name ="Name")]
        public string? MasterPartnerName { get; set; }
        [Display(Name = "Image")]
        public string? MasterPartnerLogoImageUrl { get; set; }
        [Display(Name = "URL")]
        public string? MasterPartnerWebsiteUrl { get; set; }
        [Display(Name = "Upload Image")]
        public IFormFile? file { get; set; }
    }
}
