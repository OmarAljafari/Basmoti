using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class AboutUsViewModel
    {
        public SystemSetting SystemSetting { get; set; }
        public IList<MasterService> MasterService { get; set; }
        public IList<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public IList<MasterSocialMedia> MasterSocialMedia { get; set; }
        public IList<MasterWorkingHour> MasterWorkingHour { get; set; }
    }
}
