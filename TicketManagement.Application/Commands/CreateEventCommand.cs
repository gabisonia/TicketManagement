using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Event;

namespace TicketManagement.Application.Commands
{
    public class CreateEventCommand : Command
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string VenueName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int SeatCount { get; set; }

        public override CommandExecutionResult Execute()
        {
            var @event = new Domain.Event.Event(EventName, EventDate, new Venue(new Address(Longitude, Latitude), VenueName), SeatCount);


            _unitOfWork.Save();
            return Ok(DomainOperationResult.CreateEmpty());
        }
    }
}
