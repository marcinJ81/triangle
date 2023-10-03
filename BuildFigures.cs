using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Triangle3
{

    public class BuildFigures : IBuildFigures
    {
        public List<Triangle> triangles { get; private set; }
        public List<Square> squares { get; private set; }

        private IValidation validation { get; set; }
        public BuildFigures(IValidation validation)
        {
            triangles = new List<Triangle>();
            squares = new List<Square>();
            this.validation = validation;
        }

        public void CreateNewTriangle(double a, double h)
        {
            validation.ValidationLength(a, "Triangle", "Base");
            validation.ValidationLength(h, "Triangle", "Height");
            triangles.Add(new Triangle(a, h));
        }

        public void CreateNewSquare(double a)
        {
            validation.ValidationLength(a, "Square", "Side");
            squares.Add(new Square(a));
        }     
    }

    public interface IBuildFigures
    {
        void CreateNewTriangle(double a, double h);
        void CreateNewSquare(double a);
    }
}
