﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Aspects.Exception;
using Transport.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Transport.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //Exception Log
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));


            return (IInterceptor[])classAttributes.OrderBy(x => x.Priority).ToArray();
        }


    }
}
