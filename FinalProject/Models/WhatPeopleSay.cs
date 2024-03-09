using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class WhatPeopleSay:BaseEntity
    {
        public int WhatPeopleSayId { get; set; }
        [Display(Name = "Name")]

        public string WhatPeopleSayName { get; set; }
        [Display(Name ="Description")]
        public string WhatPeopleSayDescription { get; set; }
        [Display(Name = "Image")]

        public string WhatPeopleSayImage { get; set; }
        [Display(Name = "Title")]

        public string WhatPeopleSayTitle { get; set; }
    }
}
