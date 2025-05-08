using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Triangle3
{
    public abstract class AClassNameAttribute<T>
    {
		public string Uuid { get; private set;}

        public AClassNameAttribute()
        {
            Uuid = Guid.NewGuid().ToString();
        }
    }
}
