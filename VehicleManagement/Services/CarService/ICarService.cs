using VehicleManagement.Data;
using VehicleManagement.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Services.CarService
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        Car AddCar(CarDto newCar);
    }
}
