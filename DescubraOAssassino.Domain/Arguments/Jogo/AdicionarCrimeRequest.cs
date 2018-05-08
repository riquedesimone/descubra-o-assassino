using DescubraOAssassino.Domain.Arguments.Arma;
using DescubraOAssassino.Domain.Arguments.Local;
using DescubraOAssassino.Domain.Arguments.Suspeito;
using DescubraOAssassino.Domain.Entities;

namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class AdicionarCrimeRequest
    {
        public AdicionarCrimeRequest(SuspeitoResponse suspeito, ArmaResponse arma, LocalResponse local)
        {
            Suspeito = suspeito;
            Arma = arma;
            Local = local;
        }

        public SuspeitoResponse Suspeito { get; private set; }
        public ArmaResponse Arma { get; private set; }
        public LocalResponse Local { get; private set; }
    }
}
