using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManagement.Controllers;
using VehicleManagement.Data;
using VehicleManagement.Services.VehicleTypeService;

namespace VehicleManagement.UnitTest.Controllers
{
    [TestFixture]
    class VehicleTypeControllerTest
    {
        private Mock<IVehicleTypeService> _vehicleTypeService;
        private VehicleType _vehicleType;

        [SetUp]
        public void SetUp()
        {
            _vehicleTypeService = new Mock<IVehicleTypeService>();
            _vehicleType = new VehicleType
            {
                VehicleTypeID = 1,
                Type = "Car"
            };
        }

        [Test]
        public void Get_WhenThereAreVehicleTypes_ReturnsOkStatusCode()
        {
            _vehicleTypeService.Setup(s => s.GetAllVehicleTypes()).Returns(new List<VehicleType>{ _vehicleType }.AsEnumerable());
            VehicleTypeController controller = new VehicleTypeController(_vehicleTypeService.Object);
            
            IActionResult result = controller.Get();
            var OkResult = result as OkObjectResult;
            
            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
            
        }

        [Test]
        public void Get_WhenNoVehicleTypesAdded_ReturnsNoContentStatusCode()
        {
            _vehicleTypeService.Setup(s => s.GetAllVehicleTypes()).Returns(new List<VehicleType>{ }.AsEnumerable());
            VehicleTypeController controller = new VehicleTypeController(_vehicleTypeService.Object);

            IActionResult result = controller.Get();

            Assert.That(result, Is.InstanceOf(typeof(NoContentResult)));
        }
    }
}
