using DescubraOAssassino.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DescubraOAssassino.Infra.Persistence
{
    public class DescubraOAssassinoContext : DbContext
    {
        public DescubraOAssassinoContext() : base("DescubraOAssassino")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Arma> Armas { get; set; }
        public IDbSet<Suspeito> Suspeitos { get; set; }
        public IDbSet<Local> Locais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.AddFromAssembly(typeof(DescubraOAssassinoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}