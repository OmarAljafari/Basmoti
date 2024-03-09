using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class HomeViewModel
    {
        public List<MasterSlider> MasterSlider { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public IList<MasterItemMenu> MasterItemMenu { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }
        public IList<WhatPeopleSay> WhatPeopleSay { get; set; }
        public IList<MasterOffer> MasterOffer { get; set; }
        public IList<MasterPartner> MasterPartner { get; set; }
        public IList<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public IList<MasterWorkingHour> MasterWorkingHour { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public IList<MasterSocialMedia> MasterSocialMedia { get; set; }
    }
}
