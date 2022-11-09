using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : IComputer
    {
        public IReadOnlyCollection<IComponent> Components => throw new NotImplementedException();

        public IReadOnlyCollection<IPeripheral> Peripherals => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public string Manufacturer => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public double OverallPerformance => throw new NotImplementedException();

        public void AddComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            throw new NotImplementedException();
        }

        public IComponent RemoveComponent(string componentType)
        {
            throw new NotImplementedException();
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            throw new NotImplementedException();
        }
    }
}
