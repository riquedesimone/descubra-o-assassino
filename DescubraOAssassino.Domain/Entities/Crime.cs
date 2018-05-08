using DescubraOAssassino.Domain.Arguments.Jogo;
using DescubraOAssassino.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DescubraOAssassino.Domain.Entities
{
    public class Crime : EntityGuidBase
    {
        protected Crime()
        {

        }

        public Crime(Suspeito suspeito, Local local, Arma arma)
        {
            SuspeitoId = suspeito.Id;
            LocalId = local.Id;
            ArmaId = arma.Id;
            ExpireDate = DateTime.Now.AddDays(1);
        }

        public Crime(int suspeito, int local, int arma)
        {
            SuspeitoId = suspeito;
            LocalId = local;
            ArmaId = arma;
        }

        public virtual Suspeito Suspeito { get; private set; }
        public int SuspeitoId { get; private set; }

        public virtual Local Local { get; private set; }
        public int LocalId { get; private set; }

        public virtual Arma Arma { get; private set; }
        public int ArmaId { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public EnumSituacaoJogo ChecarTeoria(TeoriaRequest request)
        {
            var errors = new List<EnumSituacaoJogo>();

            if (SuspeitoId != request.Suspeito)
            {
                errors.Add(EnumSituacaoJogo.SuspeitoIncorreto);
            }

            if (LocalId != request.Local)
            {
                errors.Add(EnumSituacaoJogo.LocalIncorreto);
            }

            if (ArmaId != request.Arma)
            {
                errors.Add(EnumSituacaoJogo.ArmaIncorreta);
            }

            if(!errors.Any())
            {
                return EnumSituacaoJogo.TeoriaCorreta;
            }

            return (errors.Count == 1) ? errors.First() : errors[new Random().Next(errors.Count)];
        }

        public static explicit operator Crime(CrimeResponse v)
        {
            return new Crime(v.Suspeito, v.Local, v.Arma);
        }
    }
}
