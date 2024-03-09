using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterOffer : BaseEntity
    {
        public int MasterOfferId { get; set; }
        [Display(Name ="Title")]
        public string? MasterOfferTitle { get; set; }
        [Display(Name = "Breef")]
        public string? MasterOfferBreef { get; set; }
        [Display(Name = "Description")]
        public string? MasterOfferDesc { get; set; }
        [Display(Name = "Image")]
        public string? MasterOfferImageUrl { get; set; }
    }
}
