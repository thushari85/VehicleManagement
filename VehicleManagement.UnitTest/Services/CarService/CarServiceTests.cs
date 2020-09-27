using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using NUnit.Framework;
using Moq;
using VehicleManagement.Services.CarService;
using VehicleManagement.Data;
using System.Linq;
using AutoMapper;
using VehicleManagement.Model.Dtos;

namespace VehicleManagement.UnitTest.Services.CarServiceTests
{
    [TestFixture]
    class CarServiceTests
    {
        private Mock<ICarRepository> _carRepository;
        private Car _car;
        private Mapper _mapper;

        [SetUp]
        public void SetUp()
        {
            Lazy<IMapper> lazyMapper = new Lazy<IMapper>(() => 
            {
                MapperConfiguration config = new MapperConfiguration(config =>
                {
                    config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    config.AddProfile<AutoMapperProfile>();
                });
                IMapper mapper = config.CreateMapper();
                return mapper;
            });
            _mapper = (Mapper)lazyMapper.Value;

            _carRepository = new Mock<ICarRepository>();

            _car = new Car
            {
                ID = 1,
                Make = "Toyota",
                Model = "Yaris",
                Engine = "500CC",
                BodyType = "Sedan",
                Wheels = 4,
                Doors = 5
            };
        }

        [Test]
        public async Task GetAllCars_WhenCalled__ReturnAllCars()
        {
            _carRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(new List<Car> { _car }.AsEnumerable()));
            var carService = new CarService(_carRepository.Object, _mapper);
            List<Car> allCars = new List<Car>
            {
                _car
            };

            var result = await carService.GetAllCars();

            Assert.That(result, Is.EqualTo(allCars));
        }

        [Test]
        public async Task AddCar_WhenCalled_ReturnAddedCar()
        {
            _carRepository.Setup(r => r.Add(_car)).Returns(Task.FromResult(_car));
            var carService = new VehicleManagement.Services.CarService.CarService(_carRepository.Object, _mapper);

            CarDto newCar = new CarDto
            {
                Make = "Toyota",
                Model = "Yaris",
                Engine = "500CC",
                BodyType = "Sedan",
                Wheels = 4,
                Doors = 5
            };

            var result = await carService.AddCar(newCar);
        }
    }
}
