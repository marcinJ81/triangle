﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using Triangle3.Figures;

namespace Triangle3
{
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
        private static readonly Validation _validation = new Validation();
        public static List<IFigure> FigureList { get; private set; } = new List<IFigure>();
        public static void CreateFigure(FigureDescriptionParameters parameters)
        {
            _validation.ValidationParameters(parameters);

            switch (parameters.FigureType.ToLower())
            {
                case "triangle":
                    FigureList.Add( new Triangle(parameters.BaseSide.Value, parameters.Height.Value, parameters.Name));
                    break;
                case "square":
                    FigureList.Add( new Square(parameters.Side.Value, parameters.Name));
                    break;
                case "circle":
                    FigureList.Add(new Circle(parameters.Radius.Value));
                    break;
                default:
                    throw new NotSupportedException($"Figure type '{parameters.FigureType}' is not supported.");
            }
        }
    }


}
