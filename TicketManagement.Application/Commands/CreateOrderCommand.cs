using System;
using TicketManagement.Application.Infrastructure;

namespace TicketManagement.Application.Commands
{
    public class CreateOrderCommand : Command
    {
        public override CommandExecutionResult Execute()
        {
            _unitOfWork.Save();
            throw new NotImplementedException();
        }
    }
}
