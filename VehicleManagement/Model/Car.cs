using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data
{
    [Table("Cars")]
    public class Car : Vehicle
    {
        [Required]
        public string Engine { get; set; }
        
        [Required]
        public int Doors { get; set; }
        
        [Required]
        public int Wheels { get; set; }
        
        [Required]
        public string BodyType { get; set; }
    }
}
