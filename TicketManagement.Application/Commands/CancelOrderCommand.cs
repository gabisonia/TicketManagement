using System;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Commands
{
    public class CancelOrderCommand : Command
    {
        public int Id { get; set; }

        public override CommandExecutionResult Execute()
        {
            _unitOfWork.Save();
            throw new NotImplementedException();
        }
    }
}
