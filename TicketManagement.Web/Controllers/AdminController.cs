using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly CommandExecutor _commandExecutor;
        private readonly QueryExecutor _queryExecutor;

        public AdminController(CommandExecutor commandExecutor, QueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Order(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CancelOrder()
        {
            return View();
        }
    }
}
