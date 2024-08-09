using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace wandermate.models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Img { get; set; } = [];
        public string Desc { get; set; } = string.Empty;
        public int Rating { get; set; }
        public bool FreeCancellation { get; set; }
        public bool ReserveNow { get; set; }
        public Hotelinfo Hotelinfo { get; set; }

        public List<Review> Reviews { get; set; } = [];

    }
}