using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.DTOs.HotelBookingDto
{
    public class HotelBookingDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string UserName { get; set; } 
        public DateTime BookingDate { get; set; }
        public int Duration { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public decimal TotalPrice { get; set; }
    }
}