using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");

            builder.HasIndex(e => e.BackorderOrderID)
                .HasDatabaseName("FK_Sales_Orders_BackorderOrderID");

            builder.HasIndex(e => e.ContactPersonID)
                .HasDatabaseName("FK_Sales_Orders_ContactPersonID");

            builder.HasIndex(e => e.CustomerID)
                .HasDatabaseName("FK_Sales_Orders_CustomerID");

            builder.HasIndex(e => e.PickedByPersonID)
                .HasDatabaseName("FK_Sales_Orders_PickedByPersonID");

            builder.HasIndex(e => e.SalespersonPersonID)
                .HasDatabaseName("FK_Sales_Orders_SalespersonPersonID");

            builder.Property(e => e.OrderID).ValueGeneratedNever();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.SalespersonPersonID).IsRequired();
            builder.Property(e => e.ContactPersonID).IsRequired();
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.ExpectedDeliveryDate).IsRequired();
            builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);
            builder.Property(e => e.IsUndersupplyBackordered).IsRequired();
            builder.Property(e => e.Comments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.DeliveryInstructions).HasColumnType("nvarchar(max)");
            builder.Property(e => e.InternalComments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.BackorderOrder)
                .WithMany(p => p.BackorderOrders)
                .HasForeignKey(d => d.BackorderOrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_BackorderOrderID");

            builder.HasOne(d => d.ContactPerson)
                .WithMany()
                .HasForeignKey(d => d.ContactPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_ContactPersonID");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_CustomerID");

            builder.HasOne(d => d.PickedByPerson)
                .WithMany(p => p.PickedByOrders)
                .HasForeignKey(d => d.PickedByPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_PickedByPersonID");

            builder.HasOne(d => d.SalespersonPerson)
                .WithMany(p => p.SalespersonOrders)
                .HasForeignKey(d => d.SalespersonPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Orders_SalespersonPersonID");
        }
    }
} 