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
        public Car Add(Car newCar)
        {
            _context.Cars.Add(newCar);
            int savedNumber = _context.SaveChanges();
            return savedNumber > 0 ? newCar : null;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
    }
}
