using FinalProject.Models;
using FinalProject.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public TransactionBookTableController(IRepository<TransactionBookTable> tbt)
        {
            Tbt = tbt;
        }

        public IRepository<TransactionBookTable> Tbt { get; }

        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            return View(Tbt.View());
        }

    }
}
