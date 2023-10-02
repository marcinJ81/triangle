using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public interface IValidation
    {
        void ValidationLength(double a, string typeObject, string typeValue);
    }

    public class Validation : IValidation
    {

        public void ValidationLength(double a, string typeObject, string typeValue)
        {
            if (a <= 0)
            {
                throw new ArgumentException($"the length of the {typeValue} of the {typeObject} must be greater than zero");
            }
        }
    }
}
