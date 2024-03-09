using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class TransactionBookTable 
    {
        public int TransactionBookTableId { get; set; }
        [Display(Name ="Full Name")]
        [Required]

        public string? TransactionBookTableFullName { get; set; }
        [Display(Name = "Email")]
        [Required]

        public string? TransactionBookTableEmail { get; set; }
        [Display(Name = "Mobile Number")]
        [Required]

        public string? TransactionBookTableMobileNumber { get; set; }
        [Display(Name = "Date")]
        [Required]
        public DateTime? TransactionBookTableDate { get; set; }
    }
}
