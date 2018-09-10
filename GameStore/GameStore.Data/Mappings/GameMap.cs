using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Mappings
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            ToTable("Game");
            HasKey(x => x.Id);
            Property(x => x.Title).HasMaxLength(80).IsRequired();
            Property(x => x.Price).IsRequired().HasColumnType("Numeric");
            Property(x => x.ReleaseDate).IsRequired();
            Property(x => x.Description).HasMaxLength(255).IsRequired();
            Property(x => x.Platform).IsRequired();
            HasRequired(x => x.Category).WithMany(x => x.Games).HasForeignKey(x => x.CategoryId);
        }
    }
}
