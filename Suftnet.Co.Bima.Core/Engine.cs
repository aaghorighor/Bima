namespace Suftnet.Co.Bima.Core
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    public class Engine :IEngine
    {
        public IServiceProvider Initialize(IServiceProvider iServiceProvider)
        {
            this.ServiceProvider = iServiceProvider;
            return ServiceProvider;
        }

        private IServiceProvider ServiceProvider { get; set; }

        protected IServiceProvider GetServiceProvider()
        {
            var accessor = this.ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context != null ? context.RequestServices : this.ServiceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetRequiredService(type);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }
    }
}
