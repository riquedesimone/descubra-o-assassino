using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories.Base;
using System;

namespace DescubraOAssassino.Domain.Inferfaces.Repositories
{
    public interface IRepositoryCrime : IRepositoryBase<Crime, Guid>
    {
    }
}
