using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class MyUserProject:IdentityUser
    {
      
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
      
        public string CreateUser { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DDTHH:MM}")]
        public DateTime CreateDate { get; set; }
        public string? EditUser { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-DDTHH:MM}")]
        public DateTime? EditDate { get; set; }
    }
}
