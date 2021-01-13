namespace Suftnet.Co.Bima.DataAccess.Repository
{
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Actions;
    
    public class UnitOfWork : IUnitOfWork
    {
        readonly v12Context _context;

        public UnitOfWork(v12Context context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
