using System;
using TicketManagement.Infrastructure.Db;

namespace TicketManagement.Application.Infrastructure
{
    public class CommandExecutor
    {
        private readonly TicketManagementDbContext _db;
        private readonly UnitOfWork _unitOfWork;

        public CommandExecutor(TicketManagementDbContext db, UnitOfWork unitOfWork)
        {
            _db = db;
        }

        public CommandExecutionResult Execute(Command command)
        {
            try
            {
                command.Resolve(_db, _unitOfWork);

                return command.Execute();
            }
            catch (Exception ex)
            {
                //LogException(ex);
                return new CommandExecutionResult
                {
                    Success = false
                };
            }
        }
    }
}
