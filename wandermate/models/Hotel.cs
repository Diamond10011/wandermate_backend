using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Img { get; set; } = [];
        public string Desc { get; set; } = string.Empty;
        public int Rating { get; set; }
        public bool FreeCancellation { get; set; }
        public bool ReserveNow { get; set; }
        public List<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();


    }
}