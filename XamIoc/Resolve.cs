using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace XamIoc
{
    public static partial class Core
    {
        /// <summary>
        /// Resolve dependencies with params in constructors
        /// </summary>
        /// <typeparam name="T">Interface to resolve</typeparam>
        /// <returns></returns>
        public static T Resolve<T>(params object[] para)
        {
            return (T)Resolve(typeof(T), para);
        }

        private static object Resolve(Type targetType, params object[] para)
        {
            var destination = InversionDict[targetType];
            //if no constructor parameter then return an instance
            if (!para.Any())
                return Activator.CreateInstance(destination);

            var tInfo = destination.GetTypeInfo();
            var constructors = tInfo.DeclaredConstructors;
            ParameterInfo[] constructorParams;
            object instance = null;

            //to confirm which constructor to use
            foreach (var constructor in constructors)
            {
                constructorParams = constructor.GetParameters();
                //if the parameters length is compatable then continue
                if (para.Length == constructorParams.Length)
                {
                    for (int i = 0; i < constructorParams.Length; i++)
                    {
                        if (constructorParams[i].ParameterType != para[i].GetType())
                            throw new ArgumentException
                                ("the given parameter does not match the required type of the parameter");
                    }
                    
                    instance = constructor.Invoke(para);
                }
            }
            if (instance == null)
                throw new NullReferenceException
                    ("the instance is null and can not be initialized, check the parameters that user input");
            return instance;
        }
    }
}
