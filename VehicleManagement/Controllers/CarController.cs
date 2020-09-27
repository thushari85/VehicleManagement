using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.Data;
using VehicleManagement.Model.Dtos;
using VehicleManagement.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Services.VehicleTypeService;

namespace VehicleManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IVehicleTypeService _vehicleTypeService;

        public CarController(ICarService carService, IVehicleTypeService vehicleTypeService)
        {
            _carService = carService;
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Car> cars = _carService.GetAllCars();
            if (cars.Count() > 0)
            {
                return Ok(cars);
            }
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Car> Add(CarDto newCar)
        {
            newCar.VehicleTypeID = _vehicleTypeService.GetAllVehicleTypes().First(t => t.Type.ToLower().Equals("car")).VehicleTypeID;
            Car addedCar = _carService.AddCar(newCar);
            if (addedCar != null)
            {
                return CreatedAtAction("Add", addedCar);
            }
            return StatusCode(500);
        }

    }

    
}
