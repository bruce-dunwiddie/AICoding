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

            builder.HasOne(d => d.PackageType)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PackageTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PackageTypeID");

            builder.HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PurchaseOrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PurchaseOrderID");

            builder.HasOne(d => d.StockItem)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrderLines_StockItemID");
        }
    }
} 