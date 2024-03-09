using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public partial class MasterCategoryMenu :BaseEntity
    {
        public MasterCategoryMenu()
        {
            MasterItemMenus = new HashSet<MasterItemMenu>();
        }

        public int MasterCategoryMenuId { get; set; }
        [Display(Name ="Name of category")]
        public string? MasterCategoryMenuName { get; set; }

        public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; }
    }
}
