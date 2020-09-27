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
        
        [Required(ErrorMessage = "Model is Required")]
        public string Model { get; set; }
        
        public int VehicleTypeID { get; set; } = 0;
        
        [Required(ErrorMessage = "Engine is Required")]
        public string Engine { get; set; }
        
        [Required(ErrorMessage = "Doors is Required")]
        [Range(1,5, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Doors { get; set; }
        
        [Required(ErrorMessage = "Wheels is Required")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Wheels { get; set; }
        
        [Required(ErrorMessage = "BodyType is Required")]
        public string BodyType { get; set; }
    }
}
