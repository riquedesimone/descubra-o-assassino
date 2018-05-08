using DescubraOAssassino.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace DescubraOAssassino.Domain.Entities.Base
{
    public abstract class EntityGuidBase : Notifiable
    {
        protected EntityGuidBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
