using TicketManagement.Infrastructure.Db;

namespace TicketManagement.Application.Infrastructure
{
    public abstract class ApplicationBase
    {
        protected TicketManagementDbContext _db;
        protected UnitOfWork _unitOfWork;

        public void Resolve(TicketManagementDbContext db, UnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }
    }
}
