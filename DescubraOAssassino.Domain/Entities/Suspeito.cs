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
    }
}
