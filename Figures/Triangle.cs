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
    public class Triangle : AClassNameAttribute<Triangle>, IArea 
    {
        private string Uuid { get; set; }
        //A change to base
        [DisplayName("Podstawa")]
        public double Base { get; private set; }
        //H change to height
        [DisplayName("Wysokość")]
        public double Height { get; private set; }
        public string Name { get; private set; }
        public Triangle(double a, double h)
            :base()
        {
            this.Uuid = base.Uuid;
            Base = a;
            Height = h;
            var propertiesName = base.GetDescription<Triangle>();
            Name = $"{Uuid} {GetDisplayName<Triangle>()} ({propertiesName[0]}: {Base} {propertiesName[1]}: {Height})";
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
