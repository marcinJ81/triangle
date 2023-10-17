using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Triangle3
{
    public abstract class AClassNameAttribute<T>
    {
        public virtual string GetDisplayName<T>()
        {
            var displayName = typeof(T)
              .GetCustomAttributes(typeof(DisplayNameAttribute), true)
              .FirstOrDefault() as DisplayNameAttribute;

            if (displayName != null)
                return displayName.DisplayName;

            return "";
        }

        public virtual List<string> GetDescription<T>()
        {
            List<string> result = new List<string>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var displayNameAttribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute));

                if (displayNameAttribute != null)
                {
                    result.Add(displayNameAttribute.DisplayName);
                }
                else
                {
                    result.Add(property.Name);
                }
            }

            return result;
        }
    }
}
