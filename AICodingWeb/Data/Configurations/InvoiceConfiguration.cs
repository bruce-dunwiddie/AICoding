using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", "Sales");

            builder.HasIndex(e => e.AccountsPersonID)
                .HasDatabaseName("FK_Sales_Invoices_AccountsPersonID");

            builder.HasIndex(e => e.BillToCustomerID)
                .HasDatabaseName("FK_Sales_Invoices_BillToCustomerID");

            builder.HasIndex(e => e.ContactPersonID)
                .HasDatabaseName("FK_Sales_Invoices_ContactPersonID");

            builder.HasIndex(e => e.CustomerID)
                .HasDatabaseName("FK_Sales_Invoices_CustomerID");

            builder.HasIndex(e => e.DeliveryMethodID)
                .HasDatabaseName("FK_Sales_Invoices_DeliveryMethodID");

            builder.HasIndex(e => e.OrderID)
                .HasDatabaseName("FK_Sales_Invoices_OrderID");

            builder.HasIndex(e => e.PackedByPersonID)
                .HasDatabaseName("FK_Sales_Invoices_PackedByPersonID");

            builder.HasIndex(e => e.SalespersonPersonID)
                .HasDatabaseName("FK_Sales_Invoices_SalespersonPersonID");

            builder.Property(e => e.InvoiceID).ValueGeneratedNever();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.BillToCustomerID).IsRequired();
            builder.Property(e => e.OrderID);
            builder.Property(e => e.DeliveryMethodID).IsRequired();
            builder.Property(e => e.ContactPersonID).IsRequired();
            builder.Property(e => e.AccountsPersonID).IsRequired();
            builder.Property(e => e.SalespersonPersonID).IsRequired();
            builder.Property(e => e.PackedByPersonID).IsRequired();
            builder.Property(e => e.InvoiceDate).IsRequired();
            builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);
            builder.Property(e => e.IsCreditNote).IsRequired();
            builder.Property(e => e.CreditNoteReason).HasMaxLength(220);
            builder.Property(e => e.Comments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.DeliveryInstructions).HasColumnType("nvarchar(max)");
            builder.Property(e => e.InternalComments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.TotalDryItems).IsRequired();
            builder.Property(e => e.TotalChillerItems).IsRequired();
            builder.Property(e => e.DeliveryRun).HasMaxLength(5);
            builder.Property(e => e.RunPosition).HasMaxLength(5);
            builder.Property(e => e.ReturnedDeliveryData).HasColumnType("nvarchar(max)");
            builder.Property(e => e.ConfirmedDeliveryTime);
            builder.Property(e => e.ConfirmedReceivedBy).HasMaxLength(4000);
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(i => i.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(i => i.BillToCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(i => i.OrderID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<DeliveryMethod>()
                .WithMany()
                .HasForeignKey(i => i.DeliveryMethodID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(i => i.ContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(i => i.AccountsPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(i => i.SalespersonPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(i => i.PackedByPersonID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 