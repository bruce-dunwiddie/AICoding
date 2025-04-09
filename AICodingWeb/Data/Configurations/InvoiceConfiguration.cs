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

            builder.HasOne(d => d.AccountsPerson)
                .WithMany(p => p.AccountsPersonInvoices)
                .HasForeignKey(d => d.AccountsPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_AccountsPersonID");

            builder.HasOne(d => d.BillToCustomer)
                .WithMany(p => p.BillToCustomerInvoices)
                .HasForeignKey(d => d.BillToCustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_BillToCustomerID");

            builder.HasOne(d => d.ContactPerson)
                .WithMany(p => p.ContactPersonInvoices)
                .HasForeignKey(d => d.ContactPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_ContactPersonID");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.CustomerInvoices)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_CustomerID");

            builder.HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.DeliveryMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_DeliveryMethodID");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_OrderID");

            builder.HasOne(d => d.PackedByPerson)
                .WithMany(p => p.PackedByPersonInvoices)
                .HasForeignKey(d => d.PackedByPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_PackedByPersonID");

            builder.HasOne(d => d.SalespersonPerson)
                .WithMany(p => p.SalespersonInvoices)
                .HasForeignKey(d => d.SalespersonPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Invoices_SalespersonPersonID");
        }
    }
} 