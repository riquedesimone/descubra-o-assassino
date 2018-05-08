using System;
using System.Linq.Expressions;
using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Infra.Persistence.Repositories.Base;

namespace DescubraOAssassino.Infra.Persistence.Repositories
{
    public class RepositoryCrime : RepositoryGuidBase<Crime, Guid>, IRepositoryCrime
    {
        protected readonly DescubraOAssassinoContext _context;

        public RepositoryCrime(DescubraOAssassinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
