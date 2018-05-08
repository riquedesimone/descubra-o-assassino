using System;

namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class AdicionarCrimeResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AdicionarCrimeResponse(Entities.Crime v)
        {
            return new AdicionarCrimeResponse()
            {
                Id = v.Id,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
