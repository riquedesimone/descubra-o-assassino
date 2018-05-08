using System;
using DescubraOAssassino.Domain.Arguments.Local;
using DescubraOAssassino.Domain.Entities.Base;

namespace DescubraOAssassino.Domain.Entities
{
    public class Local : EntityBase
    {
        protected Local() : base("")
        {

        }
        public Local(string nome) : base(nome)
        {
        }

        public Local(int id, string nome) : base(id, nome)
        {
        }

        public static explicit operator Local(LocalResponse v)
        {
            return new Local(v.Id, v.Nome);
        }
    }
}
