using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Sales;

namespace TicketManagement.Application.Commands
{
    public class CreateOrderCommand : Command
    {
        public int EventId { get; set; }

        public string Email { get; set; }

        public int TicketCount { get; set; }

        public override CommandExecutionResult Execute()
        {
            var evnt = _db.Set<Domain.Event.Event>().Find(EventId);
            var order = new Order(Email, TicketCount, EventId, evnt.Name);
            _db.Set<Order>().Add(order);
            _unitOfWork.Save();
            return Ok(DomainOperationResult.Create(order.Id));
        }
    }
}
