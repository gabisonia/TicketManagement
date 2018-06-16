using System;
using System.Linq;
using TicketManagement.Application.Infrastructure;
using TicketManagement.Domain.Sales.ReadModel;

namespace TicketManagement.Application.Queries
{
    public class OrderDetailsQuery : Query<OrderDetailsQueryResult>
    {
        public int Id { get; set; }

        public override QueryExecutionResult<OrderDetailsQueryResult> Execute()
        {
            var orderDetails = _db.Set<OrderReadModel>().FirstOrDefault(x => x.OrderId == Id);
            return Ok(new OrderDetailsQueryResult
            {
                EventName = orderDetails.EventName,
                OrderId = Id,
                TicketCount = orderDetails.TicketCount
            });
        }
    }

    public class OrderDetailsQueryResult
    {
        public string EventName { get; set; }
        public int OrderId { get; set; }
        public int TicketCount { get; set; }
    }
}
