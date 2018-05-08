using System.Collections.Generic;
using DescubraOAssassino.Domain.Arguments.Arma;
using DescubraOAssassino.Domain.Arguments.Local;
using DescubraOAssassino.Domain.Arguments.Suspeito;
using DescubraOAssassino.Domain.Entities;

namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class AllResponse
    {
        public AllResponse(IEnumerable<ArmaResponse> armas, IEnumerable<LocalResponse> locais, IEnumerable<SuspeitoResponse> suspeitos)
        {
            Armas = armas;
            Locais = locais;
            Suspeitos = suspeitos;
        }

        public IEnumerable<ArmaResponse> Armas { get; private set; }
        public IEnumerable<LocalResponse> Locais { get; private set; }
        public IEnumerable<SuspeitoResponse> Suspeitos { get; private set; }
    }
}
