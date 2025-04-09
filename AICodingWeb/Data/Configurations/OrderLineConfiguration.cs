using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLines", "Sales");

            builder.HasIndex(e => e.OrderID)
                .HasDatabaseName("FK_Sales_OrderLines_OrderID");

            builder.HasIndex(e => e.PackageTypeID)
                .HasDatabaseName("FK_Sales_OrderLines_PackageTypeID");

            builder.HasIndex(e => e.StockItemID)
                .HasDatabaseName("FK_Sales_OrderLines_StockItemID");

            builder.Property(e => e.OrderLineID).ValueGeneratedNever();
            builder.Property(e => e.OrderID).IsRequired();
            builder.Property(e => e.StockItemID).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.PackageTypeID).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(e => e.PickedQuantity);
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_OrderID");

            builder.HasOne(d => d.PackageType)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.PackageTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_PackageTypeID");

            builder.HasOne(d => d.StockItem)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_OrderLines_StockItemID");
        }
    }
} 