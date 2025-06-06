using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class StockItemTransactionConfiguration : IEntityTypeConfiguration<StockItemTransaction>
    {
        public void Configure(EntityTypeBuilder<StockItemTransaction> builder)
        {
            builder.ToTable("StockItemTransactions", "Warehouse");

            builder.HasIndex(e => e.CustomerID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_CustomerID");

            builder.HasIndex(e => e.InvoiceID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_InvoiceID");

            builder.HasIndex(e => e.PurchaseOrderID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_StockItemID");

            builder.HasIndex(e => e.SupplierID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_SupplierID");

            builder.HasIndex(e => e.TransactionTypeID)
                .HasDatabaseName("FK_Warehouse_StockItemTransactions_TransactionTypeID");

            builder.Property(e => e.StockItemTransactionID).ValueGeneratedNever();
            builder.Property(e => e.StockItemID).IsRequired();
            builder.Property(e => e.TransactionTypeID).IsRequired();
            builder.Property(e => e.CustomerID);
            builder.Property(e => e.InvoiceID);
            builder.Property(e => e.SupplierID);
            builder.Property(e => e.PurchaseOrderID);
            builder.Property(e => e.TransactionOccurredWhen).IsRequired();
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<Invoice>()
                .WithMany()
                .HasForeignKey(d => d.InvoiceID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<PurchaseOrder>()
                .WithMany()
                .HasForeignKey(d => d.PurchaseOrderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<StockItem>()
                .WithMany()
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<TransactionType>()
                .WithMany()
                .HasForeignKey(d => d.TransactionTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
} 