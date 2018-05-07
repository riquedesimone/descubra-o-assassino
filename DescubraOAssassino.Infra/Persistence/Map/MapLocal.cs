using DescubraOAssassino.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DescubraOAssassino.Infra.Persistence.Map
{
    public class MapLocal : EntityTypeConfiguration<Local>
    {
        public MapLocal()
        {
            ToTable("Locais");

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
        }
    }
}
