using System;
using DescubraOAssassino.Domain.Entities;

namespace DescubraOAssassino.Domain.Arguments.Jogo
{
    public class CrimeResponse
    {
        public Guid Id { get; set; }
        public int Suspeito { get; set; }
        public int Arma { get; set; }
        public int Local { get; set; }

        public static explicit operator CrimeResponse(Crime v)
        {
            return new CrimeResponse
            {
                Id = v.Id,
                Suspeito = v.SuspeitoId,
                Arma = v.ArmaId,
                Local = v.LocalId
            };
        }
    }
}
