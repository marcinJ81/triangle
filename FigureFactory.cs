using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Triangle3.Figures;

namespace Triangle3
{
   

    public class FigureFactory
    {
        public List<IArea> FigureList { get; private set; }

        public FigureFactory()
        {
            FigureList = new List<IArea>();
        }

        public void CreateTriangle(double baseSide,double height)
        {
            FigureList.Add(new Triangle(baseSide, height));
        }

        public void CreateSquera(double side) 
        {
            FigureList.Add(new Square(side));
        }

    }
}
