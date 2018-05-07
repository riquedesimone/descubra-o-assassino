using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Infra.Persistence.Repositories.Base;

namespace DescubraOAssassino.Infra.Persistence.Repositories
{
    public class RepositorySuspeito : RepositoryBase<Suspeito, int>, IRepositorySuspeito
    {
        protected readonly DescubraOAssassinoContext _context;

        public RepositorySuspeito(DescubraOAssassinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
