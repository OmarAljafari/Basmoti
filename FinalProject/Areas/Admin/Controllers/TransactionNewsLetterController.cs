using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsLetterController : Controller
    {
        public TransactionNewsLetterController(IRepository<TransactionNewsletter> tnl)
        {
            Tnl = tnl;
        }

        public IRepository<TransactionNewsletter> Tnl { get; }

        public ActionResult Index()
        {
            return View(Tnl.View());
        }
    }
}
