using DescubraOAssassino.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DescubraOAssassino.Infra.Persistence.Map
{
    public class MapArma : EntityTypeConfiguration<Arma>
    {
        public MapArma()
        {
            ToTable("Armas");

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
        }
    }
}
