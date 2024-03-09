using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class TransactionContactUs 
    {
        public int TransactionContactUsId { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="The field is required")]

        public string? TransactionContactUsFullName { get; set; }
        [Required]

        [Display(Name = "Email")]
        public string? TransactionContactUsEmail { get; set; }
        [Required]

        [Display(Name = "Subject")]
        public string? TransactionContactUsSubject { get; set; }
        [Required]

        [Display(Name = "Message")]
        public string? TransactionContactUsMessage { get; set; }
    }
}
