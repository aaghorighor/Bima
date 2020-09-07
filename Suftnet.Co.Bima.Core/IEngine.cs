namespace Suftnet.Co.Bima.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;

    public interface IEngine
    {
        IServiceProvider Initialize(IServiceProvider iServiceProvider);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>();
    }
}
