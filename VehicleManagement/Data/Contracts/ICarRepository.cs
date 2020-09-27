using VehicleManagement.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data
{
    public interface ICarRepository : IVehicleRepositoryBase<Car>
    {
    }
}
