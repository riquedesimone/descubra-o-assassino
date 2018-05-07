using DescubraOAssassino.Domain.Arguments.Base;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Suspeito
{
    public class AlterarSuspeitoResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AlterarSuspeitoResponse(Entities.Suspeito v)
        {
            return new AlterarSuspeitoResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ALTERADO_COM_SUCESSO.ToFormat("Suspeito")
            };
        }
    }
}
