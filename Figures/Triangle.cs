using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Triangle3.Figures
{
    public class Triangle : IFigure
    {
        //A change to base
        public double Base { get; private set; }
        //H change to height
        public double Height { get; private set; }
        public string Name { get; private set; }
        public Triangle(double a, double h, string name)
        {
            Base = a;
            Height = h;
            Name = name;
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

        public string GetName()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            return $"{this.GetType().Name}_{Base}_{Height}_{GetHashCode()}";
        }
    }
}
