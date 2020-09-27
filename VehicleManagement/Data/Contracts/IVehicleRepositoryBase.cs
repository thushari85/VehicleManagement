using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data.Contracts
{
    public interface IVehicleRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
    }
}
