using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class PackageTypeConfiguration : IEntityTypeConfiguration<PackageType>
    {
        public void Configure(EntityTypeBuilder<PackageType> builder)
        {
            builder.ToTable("PackageTypes", "Warehouse");

            builder.HasIndex(e => e.PackageTypeName)
                .HasDatabaseName("UQ_Warehouse_PackageTypes_PackageTypeName")
                .IsUnique();

            builder.Property(e => e.PackageTypeID).ValueGeneratedNever();
            builder.Property(e => e.PackageTypeName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 