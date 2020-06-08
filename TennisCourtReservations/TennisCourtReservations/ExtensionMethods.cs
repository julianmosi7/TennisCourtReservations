using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisCourtReservations; 

namespace TennisCourtReservations
{
    public static class ExtensionMethods
    {
        public static T CopyPropertiesFrom<T>(this T target, object source, string[] ignoreProperties = null)
        {
            if (ignoreProperties == null) ignoreProperties = new string[] { };
            var propsSource = source.GetType().GetProperties()
                .Where(x => x.CanRead && !ignoreProperties.Contains(x.Name));
            var propsTarget = target.GetType().GetProperties()
                .Where(x => x.CanWrite);

            propsTarget
                .Where(prop => propsSource.Any(x => x.Name == prop.Name))
                .ToList()
                .ForEach(prop =>
                {
                    var propSource = propsSource.Where(x => x.Name == prop.Name).First();
                    prop.SetValue(target, propSource.GetValue(source));
                });
            return target;
        }
    }
}
