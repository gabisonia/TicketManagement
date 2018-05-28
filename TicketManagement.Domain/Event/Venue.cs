namespace TicketManagement.Domain.Event
{
    public class Venue
    {
        public Venue()
        {

        }

        public Venue(string name, float lng, float lat)
        {
            Longitude = lng;
            Latitude = lat;
            Name = name;
        }

        public string Name { get; private set; }
        public float Longitude { get; private set; }
        public float Latitude { get; private set; }
    }
}
