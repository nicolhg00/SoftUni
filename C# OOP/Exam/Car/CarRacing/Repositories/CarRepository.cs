using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    class CarRepository : IRepository<ICar>
    {
        

        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models { get; private set; } = new List<ICar>();

        public void Add(ICar model)
        {
            if (cars == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            cars.Add(model);
            Models = cars;
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            if (cars.Contains(model))
            {
                cars.Remove(model);
                Models = cars;
                return true;
            }
            return false;
        }
    }
}
