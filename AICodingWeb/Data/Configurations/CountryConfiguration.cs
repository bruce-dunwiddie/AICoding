using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries", "Application");

            builder.HasIndex(e => e.CountryName)
                .HasDatabaseName("UQ_Application_Countries_CountryName")
                .IsUnique();

            builder.Property(e => e.CountryID).ValueGeneratedNever();
            builder.Property(e => e.CountryName).HasMaxLength(60).IsRequired();
            builder.Property(e => e.FormalName).HasMaxLength(60).IsRequired();
            builder.Property(e => e.IsoAlpha3Code).HasMaxLength(3);
            builder.Property(e => e.IsoNumericCode);
            builder.Property(e => e.CountryType).HasMaxLength(20).IsRequired();
            builder.Property(e => e.LatestRecordedPopulation);
            builder.Property(e => e.Continent).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Region).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Subregion).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Border).HasColumnType("geography");
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 