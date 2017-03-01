using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamIoc
{
    public static partial class Core
    {
        /// <summary>
        /// Bind Interface to Class
        /// </summary>
        /// <typeparam name="TSource">Interface</typeparam>
        /// <typeparam name="TDestination">Class</typeparam>
        public static void Bind<TSource, TDestination>()
        {
            InversionDict[typeof(TSource)] = typeof(TDestination);
        }
    }
}
