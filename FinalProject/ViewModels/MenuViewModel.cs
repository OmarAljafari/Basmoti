using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class MenuViewModel
    {
        public IList<MasterCategoryMenu> MasterCategorieMenu { get; set; }
        public IList<MasterItemMenu> masterItemMenu { get; set; }
        public IList<MasterPartner> MasterPartner {  get; set; }
        public SystemSetting SystemSetting { get; set; }
        public IList<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public IList<MasterSocialMedia> MasterSocialMedia { get; set; }
        public IList<MasterWorkingHour> MasterWorkingHour { get; set; }
        public MasterItemMenu Menu { get; set; }    
        public IList<MasterItemMenu> ListItem { get; set; }
    }
}
