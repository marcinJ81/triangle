using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Triangle3.Figures
{
 
    [DisplayName("Trójkąt")]
    public class Triangle : AClassNameAttribute<Triangle>, IFigure
    {
        private string Uuid { get; set; }
        //A change to base
        [DisplayName("Podstawa")]
        public double Base { get; private set; }
        //H change to height
        [DisplayName("Wysokość")]
        public double Height { get; private set; }
        //A change to name
        public string Name { get; private set; }
        public Triangle(double a, double h, string name)
            :base()
        {
            this.Uuid = base.Uuid;
            Base = a;
            Height = h;
            Name = name;
        }

        public double Area()
        {
            return (Base * Height) / 2;
        }

        public string GetName()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            return $"{this.GetType().Name}_{Base}_{Height}_{GetHashCode()}";
        }

        IFigure IPrototype<IFigure>.Clone()
        {
            return Clone();
        }

        private Triangle Clone()
        {
            return new Triangle(this.Base, this.Height, this.Name);
        }
    }
}
