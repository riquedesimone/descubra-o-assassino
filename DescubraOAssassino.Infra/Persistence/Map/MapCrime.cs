using DescubraOAssassino.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DescubraOAssassino.Infra.Persistence.Map
{
    public class MapCrime : EntityTypeConfiguration<Crime>
    {
        public MapCrime()
        {
            ToTable("Crimes");
        }
    }
}
