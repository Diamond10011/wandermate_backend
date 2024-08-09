using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.models
{
    public class Hotelinfo


    {
        public int Id { get; set; }
        public string Details { get; set; } = String.Empty;
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }



        //navigation properties  
        public Hotel Hotel { get; set; }
    }
}