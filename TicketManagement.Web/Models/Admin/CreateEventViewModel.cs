using System;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models.Admin
{
    public class CreateEventViewModel
    {
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public int SeatCount { get; set; }
        [Required]
        public string Poster { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
