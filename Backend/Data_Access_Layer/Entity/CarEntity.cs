using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entity
{
    public class CarEntity
    {
        [Key]
        public int CarId { get; set; }
        public string? Maker { get; set; }
        public string? Model { get; set; }
        public string? RentalPrice { get; set; }
       
    }
}
