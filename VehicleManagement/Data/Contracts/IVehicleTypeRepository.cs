using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data.Contracts
{
    public interface IVehicleTypeRepository
    {
        IEnumerable<VehicleType> GetAll();
    }
}
