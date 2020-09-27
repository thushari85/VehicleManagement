using AutoMapper;
using VehicleManagement.Data;
using VehicleManagement.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carRepository.GetAll();
        }

        public async Task<Car> AddCar(CarDto newCar)
        {
            Car car = _mapper.Map<Car>(newCar);
            return await _carRepository.Add(car);
        }
    }
}
