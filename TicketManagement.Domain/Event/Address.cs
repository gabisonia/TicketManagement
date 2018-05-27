namespace TicketManagement.Domain.Event
{
    public class Address
    {
        public Address(float lng, float lat)
        {
            Longitude = lng;
            Latitude = lat;
        }

        public float Longitude { get; }
        public float Latitude { get; }
    }
}
