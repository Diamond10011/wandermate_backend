using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.models
{
    [Table("Destination")]

    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Weather { get; set; } = string.Empty;
        public List<string> Img { get; set; } = [];
        public string Desc { get; set; } = string.Empty;
    }
}