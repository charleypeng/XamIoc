using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XamIoc
{
    public static partial class Core
    {
        public static readonly Dictionary<Type, Type> InversionDict = new Dictionary<Type, Type>();

        public static void AutoRegister<TSource>()
        {
            //if use does not register the type then it will not continue
            if (InversionDict == null) return;

            var type = typeof(TSource);
            var typeInfo = type.GetTypeInfo();
            var constructors = typeInfo.DeclaredConstructors;

            if (constructors == null ||constructors.Count() == 0) return;

            //foreach (var con in constructors)
            //{
            //    var parameters = con.GetParameters();
            //    if(parameters == null)
            //        XamIoc.Core.Resolve<>

            //}
        }
    }
}
