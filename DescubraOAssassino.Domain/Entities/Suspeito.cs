using System;
using DescubraOAssassino.Domain.Arguments.Suspeito;
using DescubraOAssassino.Domain.Entities.Base;

namespace DescubraOAssassino.Domain.Entities
{
    public class Suspeito : EntityBase
    {
        protected Suspeito() : base("")
        {

        }
        public Suspeito(string nome) : base(nome)
        {
        }

        public Suspeito(int id, string nome) : base(id, nome)
        {
        }

        public static explicit operator Suspeito(SuspeitoResponse v)
        {
            return new Suspeito(v.Id, v.Nome);
        }
    }
}
