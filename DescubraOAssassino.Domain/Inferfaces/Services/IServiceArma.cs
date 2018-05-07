using DescubraOAssassino.Domain.Arguments.Arma;
using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Inferfaces.Services.Base;
using System.Collections.Generic;

namespace DescubraOAssassino.Domain.Inferfaces.Services
{
    public interface IServiceArma : IServiceBase
    {
        AdicionarArmaResponse Adicionar(AdicionarArmaRequest request);

        AlterarArmaResponse Alterar(AlterarArmaRequest request);

        IEnumerable<ArmaResponse> Listar();

        ArmaResponse ObterRandomico();

    }
}
