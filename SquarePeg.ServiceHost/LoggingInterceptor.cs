using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquarePeg.ServiceHost
{
    using System.Diagnostics;

    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Intercepted Begin: " + invocation.Method.Name);
            invocation.Proceed();
            Debug.WriteLine("Intercepted End: " + invocation.Method.Name);
        }
    }
}