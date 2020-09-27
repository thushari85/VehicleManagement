using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data
{
    public abstract class Vehicle
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
        
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        
        public VehicleType VehicleType { get; set; }

        [Required]
        public int VehicleTypeID { get; set; }
    }
}
