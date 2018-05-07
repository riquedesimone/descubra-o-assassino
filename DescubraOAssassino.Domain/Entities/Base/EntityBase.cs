using DescubraOAssassino.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase(string nome)
        {
            Alterar(nome);
        }

        public EntityBase(int id, string nome)
        {
            Id = id;
            Alterar(nome);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public void Alterar(string nome)
        {
            Nome = nome;
            ValidEntity();
        }

        private void ValidEntity()
        {
            new AddNotifications<EntityBase>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, 100, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome", "3", "100"));
        }
    }
}
