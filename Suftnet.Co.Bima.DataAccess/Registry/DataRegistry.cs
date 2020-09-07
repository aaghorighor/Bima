namespace Suftnet.Co.Bima.DataAccess.Registry
{   
    using StructureMap;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Repository;

    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();               
            });

            For(typeof(IRepository<>)).Use(typeof(Repository<>)).Transient();
            For<IBimaContextInitializer>().Use<BimaContextInitializer>().Transient();
            For<IUnitOfWork>().Use<UnitOfWork>().Transient();           
        }
    }
}