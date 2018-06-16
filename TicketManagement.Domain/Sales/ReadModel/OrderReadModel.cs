namespace TicketManagement.Domain.Sales.ReadModel
{
    public class OrderReadModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int OrderId { get; set; }
        public int TicketCount { get; set; }
    }
}
