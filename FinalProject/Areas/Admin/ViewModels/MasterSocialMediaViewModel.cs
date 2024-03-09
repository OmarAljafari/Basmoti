using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterSocialMediaViewModel:BaseModel
    {
        public int MasterSocialMediaId { get; set; }
        [Display(Name = "Image")]
        public string MasterSocialMediaImageUrl { get; set; } = null!;
        [Display(Name = "URL")]
        public string MasterSocialMediaUrl { get; set; } = null!;
        [Display(Name ="Upload Image")]
        public IFormFile? file { get; set; }
    }
}
