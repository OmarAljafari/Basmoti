using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.ViewModels
{
    public class Login 
    {
        
        [Display(Name ="User Name")]
        [Required]
        public string LoginUserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        
        public string LoginPassword { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
