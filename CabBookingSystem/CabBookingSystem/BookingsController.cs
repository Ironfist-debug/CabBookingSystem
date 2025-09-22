using Microsoft.AspNetCore.Mvc;
using CabBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace CabBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookingsController : ControllerBase
    {
        private static readonly List<Booking> bookings = new();

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            if (booking == null || string.IsNullOrEmpty(booking.PickupLocation) || string.IsNullOrEmpty(booking.Destination))
            {
                return BadRequest("PickupLocation and Destination are required.");
            }

            bookings.Add(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(Guid id)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}
