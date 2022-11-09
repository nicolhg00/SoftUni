using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public string CalculateVolume()
        {
            double result = this.Length * this.Width * this.Height;
            return $"Volume - {result:f2}";
        }
        public string CalculateLateralSurfaceArea()
        {
            double result = 2 *( Length * Height) + 2 *( Width * Height);
            return $"Lateral Surface Area - {result:f2}";
        }

        public string CalculateSurfaceArea()
        {
            double result =(2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
            return $"Surface Area - {result:f2}";
        }
    }
}
