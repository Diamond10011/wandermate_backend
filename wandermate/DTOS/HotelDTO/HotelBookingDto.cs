using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.DTOS.HotelDTO
{
    public class HotelBookingDto
    {
        public int Id {get; set;}
        public string? HotelName {get; set;}
        public string? UserName {get; set;}
        public DateTime BookingDate {get; set;}
        public DateTime Checkin {get; set;}
    }
}