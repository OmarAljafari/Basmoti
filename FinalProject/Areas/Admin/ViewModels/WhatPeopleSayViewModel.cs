using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class WhatPeopleSayViewModel:BaseModel
    {
        public int WhatPeopleSayId { get; set; }
        [Display(Name ="Name")]
        public string WhatPeopleSayName { get; set; }
        [Display(Name = "Description")]

        public string WhatPeopleSayDescription { get; set; }
        [Display(Name = "Image")]

        public string WhatPeopleSayImage { get; set; }
        [Display(Name = "Title")]

        public string WhatPeopleSayTitle { get; set; }
        public IFormFile? file { get; set; }
    }
}
