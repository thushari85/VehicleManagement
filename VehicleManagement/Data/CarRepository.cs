using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Car> Add(Car newCar)
        {
            _context.Cars.Add(newCar);
            int savedNumber = await _context.SaveChangesAsync();
            return savedNumber > 0 ? newCar : null;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
