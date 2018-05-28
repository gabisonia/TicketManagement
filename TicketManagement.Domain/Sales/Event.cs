namespace TicketManagement.Domain.Sales
{
    public class Event
    {
        public Event()
        {
        }

        public Event(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
