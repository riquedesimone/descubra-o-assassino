using DescubraOAssassino.Domain.Arguments.Base;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Local
{
    public class AdicionarLocalResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AdicionarLocalResponse(Entities.Local v)
        {
            return new AdicionarLocalResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ADICIONADO_COM_SUCESSO.ToFormat("Local")
            };
        }
    }
}
