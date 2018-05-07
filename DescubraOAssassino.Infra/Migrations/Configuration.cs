namespace DescubraOAssassino.Infra.Migrations
{
    using DescubraOAssassino.Domain.Entities;
    using DescubraOAssassino.Infra.Persistence;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DescubraOAssassinoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DescubraOAssassinoContext context)
        {
            IList<Suspeito> suspeiros = new List<Suspeito>
            {
                new Suspeito("Esqueleto"),
                new Suspeito("Khan"),
                new Suspeito("Darth Vader"),
                new Suspeito("Sideshow Bob"),
                new Suspeito("Coringa"),
                new Suspeito("Duende Verde")
            };

            context.Set<Suspeito>().AddRange(suspeiros);

            IList<Local> locais = new List<Local>
            {
                new Local("Etérnia"),
                new Local("Vulcano"),
                new Local("Tatooine"),
                new Local("Springfield"),
                new Local("Gotham"),
                new Local("Nova York"),
                new Local("Sibéria"),
                new Local("Machu Picchu"),
                new Local("Show do Katinguele"),
                new Local("São Paulo")
            };

            context.Set<Local>().AddRange(locais);

            IList<Arma> armas = new List<Arma>
            {
                new Arma("Cajado Devastador"),
                new Arma("Phaser"),
                new Arma("Peixeira"),
                new Arma("Trezoitão"),
                new Arma("Sabre de Luz"),
                new Arma("Bomba")
            };

            context.Set<Arma>().AddRange(armas);

            base.Seed(context);
        }
    }
}
