using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Infra.Persistence.Repositories.Base;

namespace DescubraOAssassino.Infra.Persistence.Repositories
{
    public class RepositoryLocal : RepositoryBase<Local, int>, IRepositoryLocal
    {
        protected readonly DescubraOAssassinoContext _context;

        public RepositoryLocal(DescubraOAssassinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
