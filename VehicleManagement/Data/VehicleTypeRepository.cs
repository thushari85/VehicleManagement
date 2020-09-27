using VehicleManagement.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagement.Data
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly DataContext _context;

        public VehicleTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VehicleType>> GetAll()
        {
            return await _context.VehicleTypes.ToListAsync();
        }
    }
}
