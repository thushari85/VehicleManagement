﻿using VehicleManagement.Data;
using VehicleManagement.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Services.VehicleTypeService
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<IEnumerable<VehicleType>> GetAllVehicleTypes()
        {
            return await _vehicleTypeRepository.GetAll();
        }
    }
}
