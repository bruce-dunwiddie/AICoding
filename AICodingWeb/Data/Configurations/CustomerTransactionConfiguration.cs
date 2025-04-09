using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class CustomerTransactionConfiguration : IEntityTypeConfiguration<CustomerTransaction>
    {
        public void Configure(EntityTypeBuilder<CustomerTransaction> builder)
        {
            builder.ToTable("CustomerTransactions", "Sales");

            builder.HasIndex(e => e.CustomerID)
                .HasDatabaseName("FK_Sales_CustomerTransactions_CustomerID");

            builder.HasIndex(e => e.InvoiceID)
                .HasDatabaseName("FK_Sales_CustomerTransactions_InvoiceID");

            builder.HasIndex(e => e.PaymentMethodID)
                .HasDatabaseName("FK_Sales_CustomerTransactions_PaymentMethodID");

            builder.HasIndex(e => e.TransactionTypeID)
                .HasDatabaseName("FK_Sales_CustomerTransactions_TransactionTypeID");

            builder.Property(e => e.CustomerTransactionID).ValueGeneratedNever();
            builder.Property(e => e.CustomerID).IsRequired();
            builder.Property(e => e.TransactionTypeID).IsRequired();
            builder.Property(e => e.InvoiceID);
            builder.Property(e => e.PaymentMethodID);
            builder.Property(e => e.TransactionDate).IsRequired();
            builder.Property(e => e.AmountExcludingTax).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.OutstandingBalance).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.FinalizationDate);
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_CustomerID");

            builder.HasOne(d => d.Invoice)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.InvoiceID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_InvoiceID");

            builder.HasOne(d => d.PaymentMethod)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.PaymentMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_PaymentMethodID");

            builder.HasOne(d => d.TransactionType)
                .WithMany(p => p.CustomerTransactions)
                .HasForeignKey(d => d.TransactionTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_CustomerTransactions_TransactionTypeID");
        }
    }
} 