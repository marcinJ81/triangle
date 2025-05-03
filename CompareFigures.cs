using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public class CompareFigures<T> where T : class
    {
        public List<string> Compare<T>(List<T> figureList) where T: IArea
        {
            List<string> result = new List<string>();
            if (figureList.Count > 1)
            {
                for (int i = 0; i < figureList.Count; i++)
                {
                    if (i % 2 == 0 && i < figureList.Count - 1)
                    {
                        if (figureList[i].Area() == figureList[i + 1].Area())
                        {
                            result.Add($"{figureList[i].Name} pole wynosi {figureList[i].Area()}" +
                                $" jest równe {figureList[i + 1].Name} którego pole wynosi {figureList[i + 1].Area()}");
                        }
                        else if (figureList[i].Area() > figureList[i + 1].Area())
                        {
                            result.Add($"{figureList[i].Name} pole wynosi {figureList[i].Area()}" +
                                $" jest większe od {figureList[i + 1].Name} którego pole wynosi {figureList[i + 1].Area()}");
                        }
                        else
                        {
                            result.Add($"{figureList[i].Name} pole wynosi {figureList[i].Area()}" +
                               $" jest mniejsze od {figureList[i + 1].Name} którego pole wynosi {figureList[i + 1].Area()}");
                        }
                    }
                }
            }
            return result;
        }
    }
}
