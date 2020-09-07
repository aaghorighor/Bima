namespace Suftnet.Co.Bima.DataAccess.Registry
{   
    using StructureMap;
   
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();                     
            });
                 
        }
    }
}