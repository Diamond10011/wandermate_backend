using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId {get; set;}
        public Users User {get; set;}
        public int HotelId {get; set;}
        public Hotel Hotel {get; set;}
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}