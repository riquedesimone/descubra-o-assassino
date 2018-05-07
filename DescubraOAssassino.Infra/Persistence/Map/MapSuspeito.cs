using DescubraOAssassino.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DescubraOAssassino.Infra.Persistence.Map
{
    public class MapSuspeito : EntityTypeConfiguration<Suspeito>
    {
        public MapSuspeito()
        {
            ToTable("Suspeitos");

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
        }
    }
}
