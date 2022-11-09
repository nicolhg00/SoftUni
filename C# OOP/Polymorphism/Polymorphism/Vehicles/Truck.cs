using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditioner = 1.6;
        public Truck(double fuelQuantity, double fuelCompsumption, double tankCapacity) 
            : base(fuelQuantity, fuelCompsumption, tankCapacity)
        {
        }

        public override double FuelCompsumption => base.FuelCompsumption + AirConditioner;

        public override void Refuel(double amount)
        {
            if (base.FuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
            base.Refuel(amount * 0.95);
        }
    }
}
