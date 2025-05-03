using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Triangle3.Figures;

namespace Triangle3
{
    public class BuildFigures
    {
        public List<IFigure> Figures { get; private set; } = new List<IFigure>();

        public void AddFigure(IFigure figure)
        {
            Figures.Add(figure);
        }
    }
}
