using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3.Figures
{
    public class Triangle
    {
        //A change to base
        public double Base { get; private set; }
        //H change to height
        public double Height { get; private set; }
        public Triangle(double a, double h)
        {
            Base = a;
            Height = h;
        }

        public double Area()
        {
            return (Base * Height) / 2;
        }

        public override string ToString()
        {
            var type = typeof(Triangle);
            return type.Name;
        }
    }
}
