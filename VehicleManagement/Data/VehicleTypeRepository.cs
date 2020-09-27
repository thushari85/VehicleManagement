using VehicleManagement.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly DataContext _context;

        public VehicleTypeRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<VehicleType> GetAll()
        {
            return _context.VehicleTypes.ToList();
        }
    }
}
