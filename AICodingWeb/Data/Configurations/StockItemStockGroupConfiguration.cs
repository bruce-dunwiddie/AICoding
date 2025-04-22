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

            // Configure relationships
            builder.HasOne<StockItem>()
                .WithMany()
                .HasForeignKey(sisg => sisg.StockItemID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StockGroup>()
                .WithMany()
                .HasForeignKey(sisg => sisg.StockGroupID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 