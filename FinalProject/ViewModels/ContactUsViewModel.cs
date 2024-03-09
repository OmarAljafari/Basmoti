using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class ContactUsViewModel
    {
        public TransactionContactUs TransactionContactUs { get; set; }
        public IList<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public IList<MasterSocialMedia> MasterSocialMedia { get; set; }
        public IList<MasterWorkingHour> MasterWorkingHour { get; set; }
        public IList<MasterContactUsInformation> _MasterContactUsInformation { get; set; }

    }
}
