using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterContactUsInformationViewModel : BaseModel
    {
        public int MasterContactUsInformationId { get; set; }
        [Display(Name = "Description")]
        public string? MasterContactUsInformationIdesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterContactUsInformationImageUrl { get; set; }
        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }
        [Display(Name ="File")]
        public IFormFile? file { get; set; }
    }
}
