using System;

namespace CabBookingSystem.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; } = Guid.NewGuid();
        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
