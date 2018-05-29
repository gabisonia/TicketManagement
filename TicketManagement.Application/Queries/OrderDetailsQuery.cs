using System;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Queries
{
    public class OrderDetailsQuery : Query<OrderDetailsQueryResult>
    {
        public override QueryExecutionResult<OrderDetailsQueryResult> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class OrderDetailsQueryResult
    {
    }
}
