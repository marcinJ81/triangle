using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3.Figures
{
    // Figures/IFigure.cs
    public interface IFigure : IArea, IPrototype<IFigure>
    {
        string GetName();
    }

}
