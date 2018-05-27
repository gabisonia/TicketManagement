namespace TicketManagement.Domain.Event
{
    public class Venue
    {
        public Venue(Address address, string name)
        {
            Name = name;
            Location = address;
        }

        public string Name { get; set; }
        public Address Location { get; set; }
    }
}
