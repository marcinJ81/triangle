﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Triangle3
{
    public class BuildFigures
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
            var type = typeof(Triangle);
            PropertyInfo[] properties = type.GetProperties();
            validation.ValidationLength(a, typeof(Triangle).Name, properties[0].Name);
            validation.ValidationLength(h, typeof(Triangle).Name, properties[1].Name);
            triangles.Add(new Triangle(a, h));
        }

        public void CreateNewSquare(double a)
        {
            var type = typeof(Square);
            PropertyInfo[] properties = type.GetProperties();
            validation.ValidationLength(a, typeof(Square).Name, properties[0].Name);
            squares.Add(new Square(a));
        }
       
    }
}
