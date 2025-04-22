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

            // Configure relationships
            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(st => st.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<TransactionType>()
                .WithMany()
                .HasForeignKey(st => st.TransactionTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PurchaseOrder>()
                .WithMany()
                .HasForeignKey(st => st.PurchaseOrderID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PaymentMethod>()
                .WithMany()
                .HasForeignKey(st => st.PaymentMethodID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 