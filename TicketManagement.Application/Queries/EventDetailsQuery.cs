using System;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Queries
{
    public class EventDetailsQuery : Query<EventDetailsQueryResult>
    {
        public override QueryExecutionResult<EventDetailsQueryResult> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class EventDetailsQueryResult
    {

    }
}
