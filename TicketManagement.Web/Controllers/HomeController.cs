using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using TicketManagement.Application.Commands;
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
            //    VenueName = "t"
            //};
            //_commandExecutor.Execute(eventCreateCommand);

            var evetns = _queryExecutor.Execute<EventsListQuery, EventsListQueryResult>(new EventsListQuery());
            return View(evetns.Data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
