using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.DTOs.HotelDTO
{
    public class UpdateHotelDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Img { get; set; } = [];
        public string Desc { get; set; } = string.Empty;
        public int Rating { get; set; }
        public bool FreeCancellation { get; set; }
        public bool ReserveNow { get; set; }
    }
}