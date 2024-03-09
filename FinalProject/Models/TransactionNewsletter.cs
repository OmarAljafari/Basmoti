using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class TransactionNewsletter 
    {
        public int TransactionNewsletterId { get; set; }
        [Display( Name ="Email")]
        [Required]
        public string? TransactionNewsletterEmail { get; set; }
    }
}
