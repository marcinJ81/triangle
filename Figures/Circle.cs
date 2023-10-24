using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Triangle3.Figures
{
    [DisplayName("Okrąg")]
    public class Circle : AClassNameAttribute<Circle>, IArea
    {
        private const double Pi = 3.14;
        private string Uuid { get; set; }
        [DisplayName("Promień")]
        public double Radius { get; private set; }
        public string Name { get; private set; }
        public Circle(double radius)
            :base()
        {
            Radius = radius;
            this.Uuid = base.Uuid;
            var propertiesName = base.GetDescription<Circle>();
            Name = $"{Uuid} {GetDisplayName<Circle>()} ({propertiesName[0]}: {Radius})";
        }

        public double Area()
        {
            return Pi * Math.Sqrt(Radius);
        }
    }
}
