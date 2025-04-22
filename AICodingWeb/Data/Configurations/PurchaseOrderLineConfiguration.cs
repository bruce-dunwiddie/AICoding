using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class PurchaseOrderLineConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
        {
            builder.ToTable("PurchaseOrderLines", "Purchasing");

            builder.HasIndex(e => e.PackageTypeID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrderLines_PackageTypeID");

            builder.HasIndex(e => e.PurchaseOrderID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrderLines_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrderLines_StockItemID");

            builder.Property(e => e.PurchaseOrderLineID).ValueGeneratedNever();
            builder.Property(e => e.PurchaseOrderID).IsRequired();
            builder.Property(e => e.StockItemID).IsRequired();
            builder.Property(e => e.OrderedOuters).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.ReceivedOuters).IsRequired();
            builder.Property(e => e.PackageTypeID).IsRequired();
            builder.Property(e => e.ExpectedUnitPricePerOuter).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<PurchaseOrder>()
                .WithMany()
                .HasForeignKey(pol => pol.PurchaseOrderID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StockItem>()
                .WithMany()
                .HasForeignKey(pol => pol.StockItemID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PackageType>()
                .WithMany()
                .HasForeignKey(pol => pol.PackageTypeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 