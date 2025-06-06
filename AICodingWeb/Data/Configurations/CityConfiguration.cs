using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", "Application");

            builder.HasIndex(e => e.StateProvinceID)
                .HasDatabaseName("FK_Application_Cities_StateProvinceID");

            builder.HasIndex(e => e.CityName)
                .HasDatabaseName("IX_Application_Cities_CityName");

            builder.Property(e => e.CityID).ValueGeneratedNever();
            builder.Property(e => e.CityName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LatestRecordedPopulation);
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationship with StateProvince
            builder.HasOne<StateProvince>()
                .WithMany()
                .HasForeignKey(c => c.StateProvinceID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 