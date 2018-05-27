using System;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Queries
{
    public class OrdersListQuery : Query<OrdersListQueryResult>
    {
        public override QueryExecutionResult<OrdersListQueryResult> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class OrdersListQueryResult
    {

    }
}
