using FinalProject.Areas.Admin.ViewModels;
using FinalProject.Models;
using FinalProject.Models.Repositories;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<MasterSlider> masterSlider,IRepository<SystemSetting> systemSetting,IRepository<MasterItemMenu> masterItemMenu,IRepository<TransactionBookTable> transactionBookTable,IRepository<WhatPeopleSay> whatPeopleSay,IRepository<MasterOffer> masterOffer,IRepository<MasterPartner> masterPartner,IRepository<MasterContactUsInformation> masterContactUs,IRepository<MasterWorkingHour> masterWorkingHour,IRepository<TransactionNewsletter> transactionNewsLetter,IRepository<MasterSocialMedia> masterSocialMedia)
        {
            _MasterSlider = masterSlider;
            _SystemSetting = systemSetting;
           _MasterItemMenu = masterItemMenu;
            _TransactionBookTable = transactionBookTable;
            _WhatPeopleSay = whatPeopleSay;
            _MasterOffer = masterOffer;
           _MasterPartner = masterPartner;
            _MasterContactUs = masterContactUs;
            _MasterWorkingHour = masterWorkingHour;
            _TransactionNewsLetter = transactionNewsLetter;
            _MasterSocialMedia = masterSocialMedia;
        }


        public IRepository<MasterSlider> _MasterSlider { get; }
        public IRepository<SystemSetting> _SystemSetting { get; }
        public IRepository<MasterItemMenu> _MasterItemMenu { get; }
        public IRepository<TransactionBookTable> _TransactionBookTable { get; }
        public IRepository<WhatPeopleSay> _WhatPeopleSay { get; }
        public IRepository<MasterOffer> _MasterOffer { get; }
        public IRepository<MasterPartner> _MasterPartner { get; }
        public IRepository<MasterContactUsInformation> _MasterContactUs { get; }
        public IRepository<MasterWorkingHour> _MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> _TransactionNewsLetter { get; }
        public IRepository<MasterSocialMedia> _MasterSocialMedia { get; }

        public ActionResult Index()
        {
            var obj = new HomeViewModel
            {
                MasterSlider = _MasterSlider.ViewFormClient().ToList(),
                SystemSetting = _SystemSetting.Find(1),
                MasterItemMenu = _MasterItemMenu.ViewFormClient().OrderByDescending(x => x.MasterItemMenuId).Take(5).ToList() ,
                WhatPeopleSay = _WhatPeopleSay.ViewFormClient(),
                MasterOffer = _MasterOffer.ViewFormClient() ,  
                MasterPartner = _MasterPartner.ViewFormClient() ,
                MasterContactUsInformation = _MasterContactUs.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Footer").ToList(),
                MasterWorkingHour = _MasterWorkingHour.ViewFormClient(),
               MasterSocialMedia = _MasterSocialMedia.ViewFormClient() ,

                
            };
            
            return View(obj);
        }

        public IActionResult BookTable(HomeViewModel collection)
        {
          

            var data = new TransactionBookTable
            {
                TransactionBookTableFullName = collection.TransactionBookTable.TransactionBookTableFullName,
                TransactionBookTableEmail = collection.TransactionBookTable.TransactionBookTableEmail,
                TransactionBookTableMobileNumber =collection.TransactionBookTable.TransactionBookTableMobileNumber,
                TransactionBookTableDate = collection.TransactionBookTable.TransactionBookTableDate,
          
            };

            _TransactionBookTable.Add(data);
            return RedirectToAction("Index");
        }


        public IActionResult NewsLetter(HomeViewModel collection)
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
