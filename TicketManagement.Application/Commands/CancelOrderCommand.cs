using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Sales;

namespace TicketManagement.Application.Commands
{
    public class CancelOrderCommand : Command
    {
        public int Id { get; set; }

        public override CommandExecutionResult Execute()
        {
            var order = _db.Set<Order>().Find(Id);
            order.Cancel();
            _unitOfWork.Save();
            return Ok(DomainOperationResult.Create(Id));
        }
    }
}
