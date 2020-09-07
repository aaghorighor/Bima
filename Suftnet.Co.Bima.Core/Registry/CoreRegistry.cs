namespace Suftnet.Co.Bima.Core.Registry
{
    using StructureMap;
    
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        
            For<IEngine>().Use<Engine>().Singleton();
        }
    }
}