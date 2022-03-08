using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{
    public static class EntityHelper
    {

        public static void SetObjectProperty(string propertyName, object valueToSet, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, valueToSet);
            }
        }



    }
}
