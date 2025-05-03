using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using Triangle3.Figures;

namespace Triangle3
{
    public interface IFigureFactory
	{
		void CreateTriangle(double baseSide,double height, string name);
		void CreateSquera(double side);
        void CreateCircle(double radius);
	}	

    public class FigureFactory : IFigureFactory
    {
        public List<IArea> FigureList { get; private set; }

        public FigureFactory()
        {
            FigureList = new List<IArea>();
        }

        public void CreateTriangle(double baseSide,double height, string name)
        {
            FigureList.Add(new Triangle(baseSide, height, name));
        }

        public void CreateSquera(double side) 
        {
            FigureList.Add(new Square(side));
        }

        public void CreateCircle(double radius)
        {
            FigureList.Add(new Circle(radius));
        }
    }
}
