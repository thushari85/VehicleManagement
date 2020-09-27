using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.Data.Contracts;
using VehicleManagement.Services.VehicleTypeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Data;

namespace VehicleManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<VehicleType> vehicleTypes = _vehicleTypeService.GetAllVehicleTypes();
            if(vehicleTypes.Count() > 0)
            {
                return Ok(vehicleTypes);
            }
            return NoContent();
        }
    }
}
