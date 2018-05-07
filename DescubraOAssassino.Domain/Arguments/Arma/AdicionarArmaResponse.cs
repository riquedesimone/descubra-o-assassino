using DescubraOAssassino.Domain.Arguments.Base;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Arma
{
    public class AdicionarArmaResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AdicionarArmaResponse(Entities.Arma v)
        {
            return new AdicionarArmaResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ADICIONADA_COM_SUCESSO.ToFormat("Arma")
            };
        }
    }
}
