using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class SupplierCategoryConfiguration : IEntityTypeConfiguration<SupplierCategory>
    {
        public void Configure(EntityTypeBuilder<SupplierCategory> builder)
        {
            builder.ToTable("SupplierCategories", "Purchasing");

            builder.HasIndex(e => e.SupplierCategoryName)
                .HasDatabaseName("UQ_Purchasing_SupplierCategories_SupplierCategoryName")
                .IsUnique();

            builder.Property(e => e.SupplierCategoryID).ValueGeneratedNever();
            builder.Property(e => e.SupplierCategoryName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 