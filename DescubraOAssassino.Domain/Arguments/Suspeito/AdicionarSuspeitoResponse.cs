using System;
using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Entities;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Arguments.Suspeito
{
    public class AdicionarSuspeitoResponse : ResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator AdicionarSuspeitoResponse(Entities.Suspeito v)
        {
            return new AdicionarSuspeitoResponse
            {
                Id = v.Id,
                Nome = v.Nome,
                Message = Resources.Message.X0_ALTERADO_COM_SUCESSO.ToFormat("Suspeito")
            };
        }
        
    }
}
