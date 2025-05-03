using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Triangle3.Figures
{
    [DisplayName("Okrąg")]
    public class Circle : AClassNameAttribute<Circle>, IFigure
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
        }
        private Circle Clone()
        {
            return new Circle(this.Radius);
        }

        public double Area()
        {
            return Pi * (Radius * Radius);
        }

        public string GetName()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            return $"{this.GetType().Name}_{Radius}_{GetHashCode()}";
        }

        IFigure IPrototype<IFigure>.Clone()
        {
            return Clone();
        }
    }
}
