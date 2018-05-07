using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Arguments.Local;
using DescubraOAssassino.Domain.Inferfaces.Services.Base;
using System.Collections.Generic;

namespace DescubraOAssassino.Domain.Inferfaces.Services
{
    public interface IServiceLocal : IServiceBase
    {
        AdicionarLocalResponse Adicionar(AdicionarLocalRequest request);

        AlterarLocalResponse Alterar(AlterarLocalRequest request);

        IEnumerable<LocalResponse> Listar();

        LocalResponse ObterRandomico();
    }
}
