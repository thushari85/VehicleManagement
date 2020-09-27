using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.Data;
using VehicleManagement.Data.Contracts;
using VehicleManagement.Services.VehicleTypeService;

namespace VehicleManagement.UnitTest.Services.VehicleTypeServiceTest
{
    [TestFixture]
    class VehicleTypeServiceTest
    {
        private Mock<IVehicleTypeRepository> _vehicleTypeRepository;
        private VehicleType _vehicleType;

        [SetUp]
        public void SetUp()
        {
            _vehicleTypeRepository = new Mock<IVehicleTypeRepository>();

            _vehicleType = new VehicleType
            {
                VehicleTypeID = 1,
                Type = "Car"
            };
        }

        [Test]
        public async Task GetAllVehicleTypes_WhenCalled_ReturnAllVehicleTypes()
        {
            _vehicleTypeRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(new List<VehicleType> { _vehicleType }.AsEnumerable()));
            var vehicleTypeService = new VehicleTypeService(_vehicleTypeRepository.Object);
            List<VehicleType> vehicleTypes = new List<VehicleType>
            {
                _vehicleType
            };

            var result = await vehicleTypeService.GetAllVehicleTypes();

            Assert.That(result, Is.EqualTo(vehicleTypes));
        }
    }
}
