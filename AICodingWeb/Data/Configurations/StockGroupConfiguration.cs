using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class StockGroupConfiguration : IEntityTypeConfiguration<StockGroup>
    {
        public void Configure(EntityTypeBuilder<StockGroup> builder)
        {
            builder.ToTable("StockGroups", "Warehouse");

            builder.HasIndex(e => e.StockGroupName)
                .HasDatabaseName("UQ_Warehouse_StockGroups_StockGroupName")
                .IsUnique();

            builder.Property(e => e.StockGroupID).ValueGeneratedNever();
            builder.Property(e => e.StockGroupName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 