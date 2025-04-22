using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors", "Warehouse");

            builder.HasIndex(e => e.ColorName)
                .HasDatabaseName("UQ_Warehouse_Colors_ColorName")
                .IsUnique();

            builder.Property(e => e.ColorID).ValueGeneratedNever();
            builder.Property(e => e.ColorName).HasMaxLength(20).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 