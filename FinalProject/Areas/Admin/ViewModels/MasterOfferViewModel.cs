using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class MasterOfferViewModel:BaseModel
    {
        public int MasterOfferId { get; set; }
        [Display(Name = "Title")]
        public string? MasterOfferTitle { get; set; }
        [Display(Name = "Breef")]
        public string? MasterOfferBreef { get; set; }
        [Display(Name = "Description")]
        public string? MasterOfferDesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterOfferImageUrl { get; set; }
        [Display(Name = "Upload Image")]
        public IFormFile? file { get; set; }
    }
}
