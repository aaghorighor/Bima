namespace Suftnet.Co.Bima.DataAccess.Repository
{
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Models;
    
    public class UnitOfWork : IUnitOfWork
    {
        readonly BimaContext _context;

        public UnitOfWork(BimaContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
