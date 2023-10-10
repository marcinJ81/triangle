using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Triangle3.Figures;

namespace Triangle3
{
    public interface IBuildFigure
    {
        void BuildObject(double listObjects, int amountProperties);
    }

    public class BuildFigure<T> : IBuildFigure where T : class, new()
    {
        public List<T> objectsList { get; private set; }

        public BuildFigure()
        {
            objectsList = new List<T>();
        }

        public void BuildObject(double listObjects, int amountProperties)
        {
           
        }
    }
}
