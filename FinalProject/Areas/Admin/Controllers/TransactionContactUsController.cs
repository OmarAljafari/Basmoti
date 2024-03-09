using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public TransactionContactUsController(IRepository<TransactionContactUs> tcu)
        {
            Tcu = tcu;
        }

        public IRepository<TransactionContactUs> Tcu { get; }

        public ActionResult Index()
        {
            return View(Tcu.View());
        }
    }
}
