using DescubraOAssassino.Domain.Entities.Base;

namespace DescubraOAssassino.Domain.Entities
{
    public class Arma : EntityBase
    {
        protected Arma() : base("")
        {

        }
        public Arma(string nome) : base(nome)
        {
        }
        
        public Arma(int id, string nome) : base(id, nome)
        {
        }
    }
}
