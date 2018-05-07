namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class TeoriaRequest
    {
        public TeoriaRequest(int suspeito, int local, int arma)
        {
            Suspeito = suspeito;
            Local = local;
            Arma = arma;
        }

        public int Suspeito { get; private set; }
        public int Local { get; private set; }
        public int Arma { get; private set; }
    }
}
