using DescubraOAssassino.Domain.Arguments.Base;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Arma
{
    public class AlterarArmaResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AlterarArmaResponse(Entities.Arma v)
        {
            return new AlterarArmaResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ALTERADA_COM_SUCESSO.ToFormat("Arma")
            };
        }
    }
}
