using DescubraOAssassino.Domain.Arguments.Jogo;
using DescubraOAssassino.Domain.Inferfaces.Services.Base;
using System;

namespace DescubraOAssassino.Domain.Inferfaces.Services
{
    public interface IServiceCrime : IServiceBase
    {
        AdicionarCrimeResponse Adicionar(AdicionarCrimeRequest request);

        CrimeResponse ObterPorId(Guid id);
        
        void RemoveExpirad();
    }
}
