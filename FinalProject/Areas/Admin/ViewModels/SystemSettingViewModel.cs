using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class SystemSettingViewModel:BaseModel
    {
        public int SystemSettingId { get; set; }
        [Display(Name = "Logo1")]
        public string? SystemSettingLogoImageUrl { get; set; }
        [Display(Name = "Logo2")]
        public string? SystemSettingLogoImageUrl2 { get; set; }
        [Display(Name = "Copy Right")]
        public string? SystemSettingCopyright { get; set; }
        [Display(Name = "Title")]
        public string? SystemSettingWelcomeNoteTitle { get; set; }
        [Display(Name = "Breef")]
        public string? SystemSettingWelcomeNoteBreef { get; set; }
        [Display(Name = "Description")]
        public string? SystemSettingWelcomeNoteDesc { get; set; }
        [Display(Name = "Note URL")]
        public string? SystemSettingWelcomeNoteUrl { get; set; }
        [Display(Name = "Note Image")]
        public string? SystemSettingWelcomeNoteImageUrl { get; set; }
        [Display(Name = "Map Location")]
        public string? SystemSettingMapLocation { get; set; }
        [Display(Name ="Upload logo 1 ")]
        public IFormFile? FileLogo1 { get; set; }
        [Display(Name = "Upload logo 2 ")]
        public IFormFile? FileLogo2 { get; set; }
        [Display(Name = "Upload  Note ")]
        public IFormFile? FileNote { get; set; }



    }
}
