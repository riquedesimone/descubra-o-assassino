using DescubraOAssassino.Domain.Arguments.Base;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Local
{
    public class AlterarLocalResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AlterarLocalResponse(Entities.Local v)
        {
            return new AlterarLocalResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ALTERADO_COM_SUCESSO.ToFormat("Local")
            };
        }
    }
}
