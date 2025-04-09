using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class SupplierTransactionConfiguration : IEntityTypeConfiguration<SupplierTransaction>
    {
        public void Configure(EntityTypeBuilder<SupplierTransaction> builder)
        {
            builder.ToTable("SupplierTransactions", "Purchasing");

            builder.HasIndex(e => e.PaymentMethodID)
                .HasDatabaseName("FK_Purchasing_SupplierTransactions_PaymentMethodID");

            builder.HasIndex(e => e.PurchaseOrderID)
                .HasDatabaseName("FK_Purchasing_SupplierTransactions_PurchaseOrderID");

            builder.HasIndex(e => e.SupplierID)
                .HasDatabaseName("FK_Purchasing_SupplierTransactions_SupplierID");

            builder.HasIndex(e => e.TransactionTypeID)
                .HasDatabaseName("FK_Purchasing_SupplierTransactions_TransactionTypeID");

            builder.Property(e => e.SupplierTransactionID).ValueGeneratedNever();
            builder.Property(e => e.SupplierID).IsRequired();
            builder.Property(e => e.TransactionTypeID).IsRequired();
            builder.Property(e => e.PurchaseOrderID).IsRequired();
            builder.Property(e => e.PaymentMethodID).IsRequired();
            builder.Property(e => e.SupplierInvoiceNumber).HasMaxLength(20);
            builder.Property(e => e.TransactionDate).IsRequired();
            builder.Property(e => e.AmountExcludingTax).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.OutstandingBalance).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.PaymentMethod)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.PaymentMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_PaymentMethodID");

            builder.HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.PurchaseOrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_PurchaseOrderID");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_SupplierID");

            builder.HasOne(d => d.TransactionType)
                .WithMany(p => p.SupplierTransactions)
                .HasForeignKey(d => d.TransactionTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchasing_SupplierTransactions_TransactionTypeID");
        }
    }
} 