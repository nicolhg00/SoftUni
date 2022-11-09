using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirConditioner = 1.4;
        public Bus(double fuelQuantity, double fuelCompsumption, double tankCapacity) 
            : base(fuelQuantity, fuelCompsumption, tankCapacity)
        {
        }
        public bool IsEmpty { get; set; }
        public override double FuelCompsumption => this.IsEmpty 
            ? base.FuelCompsumption
            : base.FuelCompsumption + AirConditioner;
    }
}
