using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("InvoiceLines", "Sales");

            builder.HasKey(il => il.InvoiceLineID);

            builder.Property(il => il.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(il => il.Quantity)
                .IsRequired();

            builder.Property(il => il.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(il => il.TaxRate)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(il => il.TaxAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(il => il.LineProfit)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(il => il.ExtendedPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(il => il.LastEditedBy)
                .IsRequired();

            builder.Property(il => il.LastEditedWhen)
                .IsRequired();

            // Relationships
            builder.HasOne(il => il.Invoice)
                .WithMany(i => i.InvoiceLines)
                .HasForeignKey(il => il.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(il => il.StockItem)
                .WithMany(si => si.InvoiceLines)
                .HasForeignKey(il => il.StockItemID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 