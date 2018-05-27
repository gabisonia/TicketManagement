using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManagement.Domain.Sales
{
    public class Event
    {
        public Event(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
