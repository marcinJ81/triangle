using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public interface ICompareObject
    {
        bool EqualsType(object obj, object obj2);
    }

    public class CompareObject<T> : ICompareObject
    {
        public bool EqualsType(object obj, object obj2)
        {
            if (obj == null && obj2 == null)
            {
                return true;
            }

            if (obj == null || obj2 == null || obj.GetType() != obj2.GetType())
            {
                return false;
            }

            return true;
        }
    }
}
