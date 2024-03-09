using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class Register 
    {
       
        [Display(Name ="User name")]
        [Required]
        public string RegisterName { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string RegisterEmail { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        
        public string RegisterPassword { get; set; }

        public bool RegisterAccept { get; set; }
    }
}
