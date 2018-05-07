using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Arguments.Suspeito;
using DescubraOAssassino.Domain.Inferfaces.Services.Base;
using System.Collections.Generic;

namespace DescubraOAssassino.Domain.Inferfaces.Services
{
    public interface IServiceSuspeito : IServiceBase
    {
        AdicionarSuspeitoResponse Adicionar(AdicionarSuspeitoRequest request);

        AlterarSuspeitoResponse Alterar(AlterarSuspeitoRequest request);

        IEnumerable<SuspeitoResponse> Listar();

        SuspeitoResponse ObterRandomico();
    }
}
