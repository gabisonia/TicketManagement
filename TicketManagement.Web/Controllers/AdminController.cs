using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Commands;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Web.Models.Admin;

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

        [HttpGet]
        public IActionResult CreateEvent()
        {
            var model = new CreateEventViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateEvent(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createEventCommandResult = _commandExecutor.Execute(new CreateEventCommand()
                {
                    Description = model.Description,
                    EventDate = model.EventDate,
                    EventName = model.EventName,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Poster = model.Poster,
                    SeatCount = model.SeatCount,
                    VenueName = model.VenueName,
                    VideoUrl = model.VideoUrl
                });
                if (createEventCommandResult.Success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
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
