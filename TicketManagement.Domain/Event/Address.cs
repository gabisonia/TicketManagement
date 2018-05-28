namespace TicketManagement.Domain.Event
{
    public class Address
    {
        public Address()
        {

        }

        public Address(float lng, float lat)
        {
            Longitude = lng;
            Latitude = lat;
        }

        public float Longitude { get; private set; }
        public float Latitude { get; private set; }
    }
}
