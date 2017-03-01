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
        /// Create instance that inherits interface
        /// </summary>
        /// <typeparam name="TSource">Interface</typeparam>
        /// <returns></returns>
        public static TSource GetInstance<TSource>()
        {
            try
            {
                return (TSource)GetSingleObject(typeof(TSource));
            }
            catch (Exception ex)
            {
                throw new Exception("the type of source can not be converted into the target source", ex);
            }         
        }

        private static object GetSingleObject(Type targetType)
        {
            var destination = InversionDict[targetType];

            return Activator.CreateInstance(destination);
        }
    }
}
