using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using Triangle3.Figures;

namespace Triangle3
{
 //   public interface IFigureFactory
	//{
	//	void CreateTriangle(double baseSide,double height, string name);
	//	void CreateSquera(double side);
 //       void CreateCircle(double radius);
	//}	

 //   public class FigureFactory : IFigureFactory
 //   {
 //       public List<IArea> FigureList { get; private set; }

 //       public FigureFactory()
 //       {
 //           FigureList = new List<IArea>();
 //       }

 //       public void CreateTriangle(double baseSide,double height, string name)
 //       {
 //           FigureList.Add(new Triangle(baseSide, height, name));
 //       }

 //       public void CreateSquera(double side) 
 //       {
 //           FigureList.Add(new Square(side));
 //       }

 //       public void CreateCircle(double radius)
 //       {
 //           FigureList.Add(new Circle(radius));
 //       }
 //   }

    public class FigureDescriptionParameters
    {
        public string FigureType { get;  set; }
        public string Name { get;  set; }
        public double? BaseSide { get;  set; }
        public double? Height { get;  set; }
        public double? Side { get; set; }
        public double? Radius { get;  set; }
    }

    public class FigureFactory
    {
        public static List<IFigure> FigureList { get; private set; } = new List<IFigure>();
        public static void CreateFigure(FigureDescriptionParameters parameters)
        {
            switch (parameters.FigureType.ToLower())
            {
                case "triangle":
                    if (parameters.BaseSide == null && parameters.Height == null)
                        throw new ArgumentException("Triangle requires 2 parameters: base and height.");
                    FigureList.Add( new Triangle(parameters.BaseSide.Value, parameters.Height.Value, parameters.Name));
                    break;
                case "square":
                    if (parameters.Side == null)
                        throw new ArgumentException("Square requires 1 parameter: side.");
                    FigureList.Add( new Square(parameters.Side.Value, parameters.Name));
                    break;
                case "circle":
                    if (parameters.Radius == null)
                        throw new ArgumentException("Circle requires 1 parameter: radius.");
                    FigureList.Add(new Circle(parameters.Radius.Value));
                    break;
                default:
                    throw new NotSupportedException($"Figure type '{parameters.FigureType}' is not supported.");
            }
        }
    }


}
