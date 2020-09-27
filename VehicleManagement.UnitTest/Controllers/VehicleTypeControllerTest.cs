﻿using Microsoft.AspNetCore.Mvc;
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
            List<VehicleType> expectedResult = new List<VehicleType> { _vehicleType };
            _vehicleTypeService.Setup(s => s.GetAllVehicleTypes()).Returns(expectedResult.AsEnumerable());
            VehicleTypeController controller = new VehicleTypeController(_vehicleTypeService.Object);
            
            IActionResult result = controller.Get();
            var okResult = result as OkObjectResult;
            var resultValue = okResult.Value;
            
            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
            Assert.That(resultValue, Is.EqualTo(expectedResult));
            
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
