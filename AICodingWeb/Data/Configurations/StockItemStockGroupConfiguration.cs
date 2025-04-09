using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class StockItemStockGroupConfiguration : IEntityTypeConfiguration<StockItemStockGroup>
    {
        public void Configure(EntityTypeBuilder<StockItemStockGroup> builder)
        {
            builder.ToTable("StockItemStockGroups", "Warehouse");

            builder.HasIndex(e => e.StockGroupID)
                .HasDatabaseName("FK_Warehouse_StockItemStockGroups_StockGroupID");

            builder.HasIndex(e => e.StockItemID)
                .HasDatabaseName("FK_Warehouse_StockItemStockGroups_StockItemID");

            builder.Property(e => e.StockItemStockGroupID).ValueGeneratedNever();
            builder.Property(e => e.StockItemID).IsRequired();
            builder.Property(e => e.StockGroupID).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.StockGroup)
                .WithMany(p => p.StockItemStockGroups)
                .HasForeignKey(d => d.StockGroupID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockGroupID");

            builder.HasOne(d => d.StockItem)
                .WithMany(p => p.StockItemStockGroups)
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockItemID");
        }
    }
} 