using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagement.Data;

namespace VehicleManagement.Services.VehicleTypeService
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetAllVehicleTypes();
    }
}
