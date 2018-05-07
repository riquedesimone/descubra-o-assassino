using DescubraOAssassino.Domain.Arguments.Jogo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DescubraOAssassino.Domain.Entities
{
    public class Crime
    {
        public Crime(Suspeito suspeito, Local local, Arma arma)
        {
            Suspeito = suspeito;
            Local = local;
            Arma = arma;
        }

        public Suspeito Suspeito { get; private set; }
        public Local Local { get; private set; }
        public Arma Arma { get; private set; }

        public EnumSituacaoJogo ChecarTeoria(TeoriaRequest request)
        {
            var errors = new List<EnumSituacaoJogo>();

            if (Suspeito.Id != request.Suspeito)
            {
                errors.Add(EnumSituacaoJogo.SuspeitoIncorreto);
            }

            if (Local.Id != request.Local)
            {
                errors.Add(EnumSituacaoJogo.LocalIncorreto);
            }

            if (Arma.Id != request.Arma)
            {
                errors.Add(EnumSituacaoJogo.ArmaIncorreta);
            }

            if(!errors.Any())
            {
                return EnumSituacaoJogo.TeoriaCorreta;
            }

            return (errors.Count == 1) ? errors.First() : errors[new Random().Next(errors.Count)];
        }

    }
}
