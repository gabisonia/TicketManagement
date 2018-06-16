using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Application.Queries;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommandExecutor _commandExecutor;
        private readonly QueryExecutor _queryExecutor;

        public HomeController(CommandExecutor commandExecutor, QueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        public IActionResult Index()
        {
            //var eventCreateCommand = new CreateEventCommand()
            //{
            //    EventDate = DateTime.Now,
            //    EventName = "test",
            //    Latitude = 1,
            //    Longitude = 2,
            //    SeatCount = 23,
            //    VenueName = "t",
            //    Description = "test descrition",
            //    Poster = "https://www.google.ge/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png",
            //    VideoUrl = "https://www.youtube.com/embed/wUTd35A7I"
            //};
            //_commandExecutor.Execute(eventCreateCommand);

            var evetns = _queryExecutor.Execute<EventsListQuery, EventsListQueryResult>(new EventsListQuery());
            return View(evetns.Data);
        }

        public IActionResult Details(int id)
        {
            var eventDetails = _queryExecutor.Execute<EventDetailsQuery, EventDetailsQueryResult>(new EventDetailsQuery()
            {
                Id = id
            });
            if (!eventDetails.Success)
                return NotFound();

            return View(eventDetails.Data);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
