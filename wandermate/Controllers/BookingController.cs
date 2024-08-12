using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.Data;

using wandermate.DTOS.HotelDTO;

namespace wandermate.Controllers
{
    [ApiController]
    [Route("wandermate/Booking")]
    // [Authorize]
    public class BookingController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _context.HotelBooking
            .Include(h => h.Hotel)
            .Include(u => u.User)
            .ToListAsync();

            var bookingDTOs = bookings.Select(booking => new HotelBookingDto
            {
                Id = booking.Id,
                HotelName = booking.Hotel.Name,
                UserName = booking.User.Username,
                BookingDate = booking.BookingDate,
                Checkin = booking.Checkin,
            }).ToList();

            return Ok(bookingDTOs);
        }

        
    }
}