using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditioner = 0.9;
        public Car(double fuelCompsumption, double fuelQuantity, double tankCapacity) 
            : base(fuelCompsumption, fuelQuantity, tankCapacity)
        {

        }

        public override double FuelCompsumption => base.FuelCompsumption + AirConditioner;
    }
}
