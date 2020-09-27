using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManagement.Controllers;
using VehicleManagement.Data;
using VehicleManagement.Model.Dtos;
using VehicleManagement.Services.CarService;
using VehicleManagement.Services.VehicleTypeService;

namespace VehicleManagement.UnitTest.Controllers
{
    [TestFixture]
    class CarControllerTest
    {
        private Mock<ICarService> _carService;
        private Mock<IVehicleTypeService> _vehicleTypeService;
        private Car _car;
        private VehicleType _vehicleType;

        [SetUp]
        public void SetUp()
        {
            _carService = new Mock<ICarService>();
            _vehicleTypeService = new Mock<IVehicleTypeService>();
            _vehicleType = new VehicleType
            {
                VehicleTypeID = 1,
                Type = "Car"
            };
            _vehicleTypeService.Setup(vt => vt.GetAllVehicleTypes()).Returns(new List<VehicleType> { _vehicleType }.AsEnumerable());
            _car = new Car
            {
                ID = 1,
                Make = "Toyota",
                Model = "Yaris",
                BodyType = "Sedan",
                Engine = "400CC",
                Wheels = 4,
                Doors = 5,
                VehicleTypeID = 1
            };
        }

        [Test]
        public void Get_WhenNoCarsAdded_ReturnsNoContentStatusCode()
        {
            _carService.Setup(cs => cs.GetAllCars()).Returns(new List<Car> { }.AsEnumerable());
            CarController controller = new CarController(_carService.Object, _vehicleTypeService.Object);

            IActionResult result = controller.Get();

            Assert.That(result, Is.InstanceOf(typeof(NoContentResult)));
        }

        [Test]
        public void Get_WhenThereAreCars_ReturnsOkStatusCode()
        {
            _carService.Setup(cs => cs.GetAllCars()).Returns(new List<Car> { _car }.AsEnumerable());
            CarController controller = new CarController(_carService.Object, _vehicleTypeService.Object);

            IActionResult result = controller.Get();

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void Get_WhenThereAreCars_ReturnsListOfCars()
        {
            List<Car> expectedResult = new List<Car> { _car };
            _carService.Setup(cs => cs.GetAllCars()).Returns(expectedResult.AsEnumerable());
            CarController controller = new CarController(_carService.Object, _vehicleTypeService.Object);

            IActionResult result = controller.Get();
            object resultValue = (result as OkObjectResult).Value;
            Assert.That(resultValue, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_WhenCalled_ReturnsCreatedStatusCode()
        {
            CarDto newCar = new CarDto
            {
                Make = "Toyota",
                Model = "Yaris",
                BodyType = "Hatchback",
                Engine = "500CC",
                Wheels = 4,
                Doors = 3,
                VehicleTypeID = _vehicleType.VehicleTypeID
            };
            Car expectedResult = new Car
            {
                Make = "Toyota",
                Model = "Yaris",
                BodyType = "Hatchback",
                Engine = "500CC",
                Wheels = 4,
                Doors = 3,
                VehicleTypeID = _vehicleType.VehicleTypeID
            };

            _carService.Setup(cs => cs.AddCar(newCar)).Returns(expectedResult);
            CarController controller = new CarController(_carService.Object, _vehicleTypeService.Object);

            ActionResult result = controller.Add(newCar).Result;
            var createdResult = result as ObjectResult;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
            Assert.That(createdResult.Value, Is.EqualTo(expectedResult));
        }
    }
}
