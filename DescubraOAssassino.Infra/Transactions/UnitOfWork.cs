using DescubraOAssassino.Infra.Persistence;

namespace DescubraOAssassino.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DescubraOAssassinoContext _context;

        public UnitOfWork(DescubraOAssassinoContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
