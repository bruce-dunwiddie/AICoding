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

            // Configure relationships
            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(o => o.SalespersonPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(o => o.PickedByPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(o => o.ContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(o => o.BackorderOrderID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 