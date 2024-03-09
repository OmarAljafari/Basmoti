using FinalProject.Models;
using FinalProject.Models.Repositories;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class TransactionContactUsController : Controller
    {
        public TransactionContactUsController(IRepository<TransactionContactUs> transactionContactUs,IRepository<MasterContactUsInformation> masterContactUsInformation,IRepository<TransactionNewsletter>transactionNewsLetter,IRepository<SystemSetting>systemSetting,IRepository<MasterWorkingHour>masterWorkingHour,IRepository<MasterSocialMedia>masterSocialMedia)
        {
            _TransactionContactUs = transactionContactUs;
            _MasterContactUsInformation = masterContactUsInformation;
            _TransactionNewsLetter = transactionNewsLetter;
            _SystemSetting = systemSetting;
            _MasterWorkingHour = masterWorkingHour;
            _MasterSocialMedia = masterSocialMedia;

        }

        public IRepository<TransactionContactUs> _TransactionContactUs { get; }
        public IRepository<MasterContactUsInformation> _MasterContactUsInformation { get; }
        public IRepository<TransactionNewsletter> _TransactionNewsLetter { get; }
        public IRepository<SystemSetting> _SystemSetting { get; }
        public IRepository<MasterWorkingHour> _MasterWorkingHour { get; }
        public IRepository<MasterSocialMedia> _MasterSocialMedia { get; }

        public IActionResult Index()
        {
            var data = new ContactUsViewModel
            {
                SystemSetting = _SystemSetting.Find(1),
                MasterContactUsInformation = _MasterContactUsInformation.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Footer").ToList(),
                MasterSocialMedia = _MasterSocialMedia.ViewFormClient(),
                MasterWorkingHour = _MasterWorkingHour.ViewFormClient(),

                _MasterContactUsInformation = _MasterContactUsInformation.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Contact Us").ToList(),
            };
            return View(data);
        }


        public IActionResult add(ContactUsViewModel collection)
        {
            var obj = new TransactionContactUs()
            {
                TransactionContactUsEmail = collection.TransactionContactUs.TransactionContactUsEmail,
                TransactionContactUsFullName = collection.TransactionContactUs.TransactionContactUsFullName,
                TransactionContactUsSubject = collection.TransactionContactUs.TransactionContactUsSubject,
                TransactionContactUsMessage = collection.TransactionContactUs.TransactionContactUsMessage,
  
            };
            _TransactionContactUs.Add(obj);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult NewsLetter(ContactUsViewModel collection)
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
