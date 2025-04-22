using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvinces", "Application");

            builder.HasIndex(e => e.CountryID)
                .HasDatabaseName("FK_Application_StateProvinces_CountryID");

            builder.HasIndex(e => e.StateProvinceName)
                .HasDatabaseName("UQ_Application_StateProvinces_StateProvinceName")
                .IsUnique();

            builder.Property(e => e.StateProvinceID).ValueGeneratedNever();
            builder.Property(e => e.StateProvinceCode).HasMaxLength(5).IsRequired();
            builder.Property(e => e.StateProvinceName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.CountryID).IsRequired();
            builder.Property(e => e.SalesTerritory).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Border).HasColumnType("geography");
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationship with Country
            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(sp => sp.CountryID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 