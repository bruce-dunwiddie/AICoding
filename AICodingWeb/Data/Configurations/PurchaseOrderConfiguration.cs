using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrders", "Purchasing");

            builder.HasIndex(e => e.ContactPersonID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrders_ContactPersonID");

            builder.HasIndex(e => e.DeliveryMethodID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrders_DeliveryMethodID");

            builder.HasIndex(e => e.SupplierID)
                .HasDatabaseName("FK_Purchasing_PurchaseOrders_SupplierID");

            builder.Property(e => e.PurchaseOrderID).ValueGeneratedNever();
            builder.Property(e => e.SupplierID).IsRequired();
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.DeliveryMethodID).IsRequired();
            builder.Property(e => e.ContactPersonID).IsRequired();
            builder.Property(e => e.ExpectedDeliveryDate).IsRequired();
            builder.Property(e => e.SupplierReference).HasMaxLength(20);
            builder.Property(e => e.IsOrderFinalized).HasMaxLength(1).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.ContactPerson)
                .WithMany(p => p.ContactPersonPurchaseOrders)
                .HasForeignKey(d => d.ContactPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_ContactPersonID");

            builder.HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.DeliveryMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_DeliveryMethodID");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_PurchaseOrders_SupplierID");
        }
    }
} 