using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3.Figures
{
    public class Square : IFigure
    {
        public string Name { get; private set; }
        public double Side { get; private set; }

        public Square(double a)
        {
            Side = a;
            Name = $"{nameof(Square)} (SideA: {Side})";
        }

        public double Area()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"{nameof(Square)} (SideA: {Side})";
        }
    }
}
