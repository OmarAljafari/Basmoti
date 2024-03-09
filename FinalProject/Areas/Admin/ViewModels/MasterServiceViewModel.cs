using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterServiceViewModel:BaseModel
    {
        public int MasterServiceId { get; set; }
        [Display(Name = "Title")]
        public string? MasterServiceTitle { get; set; }
        [Display(Name = "Description")]
        public string? MasterServiceDesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterServiceImage { get; set; }
        [Display(Name ="Upload Image")]
        public IFormFile? file { get; set; }
    }
}
