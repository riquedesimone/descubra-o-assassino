namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class TeoriaResponse
    {
        public TeoriaResponse(EnumSituacaoJogo situacao)
        {
            SituacaoJogo = situacao;
            
            switch(situacao)
            {
                case EnumSituacaoJogo.ArmaIncorreta:
                    Message = Resources.Message.ARMA_INCORRETA;
                    break;
                case EnumSituacaoJogo.LocalIncorreto:
                    Message = Resources.Message.LOCAL_INCORRETO;
                    break;
                case EnumSituacaoJogo.SuspeitoIncorreto:
                    Message = Resources.Message.SUSPEITO_INCORRETO;
                    break;
                case EnumSituacaoJogo.TeoriaCorreta:
                    Message = Resources.Message.TEORIA_CORRETA;
                    break;
            }
        }

        public EnumSituacaoJogo SituacaoJogo { get; private set; }
        public string Message { get; private set; }
    }
}
