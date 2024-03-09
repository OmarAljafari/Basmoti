using FinalProject.Models;
using FinalProject.Models.Repositories;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MenuController : Controller
    {
        public MenuController(IRepository<MasterCategoryMenu> masterCategoryMenu,IRepository<MasterItemMenu> masterItemMenu,IRepository<MasterPartner> masterPartner,IRepository<TransactionNewsletter>transactionNewsLetter,IRepository<MasterWorkingHour>masterWorkingHour,IRepository<MasterSocialMedia>masterSocialMedia,IRepository<MasterContactUsInformation>masterContactUs,IRepository<SystemSetting>systemSetting,IRepository<MasterItemMenu> masterMenu)
        {
            _MasterCategoryMenu = masterCategoryMenu;
            _MasterItemMenu = masterItemMenu;
            _MasterPartner = masterPartner;
            _TransactionNewsLetter = transactionNewsLetter;
            _MasterWorkingHour = masterWorkingHour;
            _MasterSocialMedia = masterSocialMedia;
            _MasterContactUs = masterContactUs;
            _SystemSetting = systemSetting;
            _MasterMenu = masterMenu;
        }

        public IRepository<MasterCategoryMenu> _MasterCategoryMenu { get; }
        public IRepository<MasterItemMenu> _MasterItemMenu { get; }
        public IRepository<MasterPartner> _MasterPartner { get; }
        public IRepository<TransactionNewsletter> _TransactionNewsLetter { get; }
        public IRepository<MasterWorkingHour> _MasterWorkingHour { get; }
        public IRepository<MasterSocialMedia> _MasterSocialMedia { get; }
        public IRepository<MasterContactUsInformation> _MasterContactUs { get; }
        public IRepository<SystemSetting> _SystemSetting { get; }
        public IRepository<MasterItemMenu> _MasterMenu { get; }

        public IActionResult Index(int idCategory)
        {

            var obj = new MenuViewModel();
            obj.MasterCategorieMenu = _MasterCategoryMenu.ViewFormClient();
            obj.MasterPartner = _MasterPartner.ViewFormClient();
            obj.MasterContactUsInformation = _MasterContactUs.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Footer").ToList();
            obj.MasterWorkingHour = _MasterWorkingHour.ViewFormClient();
            obj.MasterSocialMedia = _MasterSocialMedia.ViewFormClient();
            obj.SystemSetting = _SystemSetting.Find(1);
            obj.masterItemMenu = _MasterItemMenu.ViewFormClient().ToList();

            //if (idCategory ==0)
                
            //    obj.masterItemMenu = _MasterItemMenu.ViewFormClient().ToList();
            //else
            //    obj.masterItemMenu = _MasterItemMenu.ViewFormClient().Where(x => x.MasterCategoryMenuId == idCategory).ToList();


            return View(obj);
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


        public IActionResult details(int id)
        {
            var obj = new MenuViewModel();
            obj.Menu = _MasterMenu.Find(id);
            obj.MasterContactUsInformation = _MasterContactUs.ViewFormClient().Where(x => x.MasterContactUsInformationRedirect == "Footer").ToList();
            obj.MasterWorkingHour = _MasterWorkingHour.ViewFormClient();
            obj.MasterSocialMedia = _MasterSocialMedia.ViewFormClient();
            obj.SystemSetting = _SystemSetting.Find(1);
            obj.ListItem = _MasterItemMenu.ViewFormClient().OrderByDescending(x => x.MasterItemMenuId).Take(3).ToList();
            return View(obj);

        }
    }


}
