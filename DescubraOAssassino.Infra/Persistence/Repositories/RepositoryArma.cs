using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Infra.Persistence.Repositories.Base;

namespace DescubraOAssassino.Infra.Persistence.Repositories
{
    public class RepositoryArma : RepositoryBase<Arma, int>, IRepositoryArma
    {
        protected readonly DescubraOAssassinoContext _context;

        public RepositoryArma(DescubraOAssassinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
