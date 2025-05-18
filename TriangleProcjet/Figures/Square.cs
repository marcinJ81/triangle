using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Triangle3.Figures
{
    [DisplayName("Kwadrat")]
    public class Square : AClassNameAttribute<Square>, IFigure
    {
        private string Uuid { get; set; }
        [DisplayName("Bok")]
        public double Side { get; private set; }
        public string Name { get; private set; }

        public Square(double a, string squareName)
            : base()
        {
            Uuid = base.Uuid;
            Side = a;
            Name = squareName;
        }

        public double Area()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"{nameof(Square)} (SideA: {Side})";
        }

        public string GetName()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            return $"{this.GetType().Name}_{Side}_{GetHashCode()}";
        }

        private Square Clone()
        {
            //to chage clony uid? maybe no
            return new Square(Side, Name);
        }

        IFigure IPrototype<IFigure>.Clone()
        {
            return Clone();
        }
    }
}
