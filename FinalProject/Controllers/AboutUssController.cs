using FinalProject.Models;
using FinalProject.Models.Repositories;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AboutUssController : Controller
    {
        public AboutUssController(IRepository<SystemSetting> syetemSetting,IRepository<MasterService> masterService,IRepository<TransactionNewsletter> transactionNewsLetter,IRepository<MasterContactUsInformation> masterContactUs,IRepository<MasterSocialMedia>masterSocialMedia,IRepository<MasterWorkingHour>masterWorkingHour)
        {
            _SyetemSetting = syetemSetting;
            _MasterService = masterService;
            _TransactionNewsLetter = transactionNewsLetter;
            _MasterContactUs = masterContactUs;
            _MasterSocialMedia = masterSocialMedia;
            _MasterWorkingHour = masterWorkingHour;
        }

        public IRepository<SystemSetting> _SyetemSetting { get; }
        public IRepository<MasterService> _MasterService { get; }
        public IRepository<TransactionNewsletter> _TransactionNewsLetter { get; }
        public IRepository<MasterContactUsInformation> _MasterContactUs { get; }
        public IRepository<MasterSocialMedia> _MasterSocialMedia { get; }
        public IRepository<MasterWorkingHour> _MasterWorkingHour { get; }

        public IActionResult Index()
        {
            var obj = new AboutUsViewModel
            {
                SystemSetting = _SyetemSetting.Find(1),
                MasterService = _MasterService.ViewFormClient(),
                MasterContactUsInformation = _MasterContactUs.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Footer").ToList(),
                MasterSocialMedia = _MasterSocialMedia.ViewFormClient(),
                MasterWorkingHour = _MasterWorkingHour.ViewFormClient()
            };
            return View(obj);
        }

        public IActionResult NewsLetter(AboutUsViewModel collection)
        {

            var data = new TransactionNewsletter
            {
                TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail,
               

            };

            _TransactionNewsLetter.Add(data);
            return RedirectToAction("Index");
        }
    }
}
