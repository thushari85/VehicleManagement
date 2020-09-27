using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.Data;

namespace VehicleManagement.Model.Dtos
{
    public class CarDto
    {
        [Required(ErrorMessage = "Make is Required")]
        public string Make { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        [Required]
        public int VehicleTypeID { get; set; } = 0;
        
        [Required]
        public string Engine { get; set; }
        
        [Required]
        public int Doors { get; set; } = 5;
        
        [Required]
        public int Wheels { get; set; } = 4;
        
        [Required]
        public string BodyType { get; set; }
    }
}
