using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods", "Application");

            builder.HasIndex(e => e.PaymentMethodName)
                .HasDatabaseName("UQ_Application_PaymentMethods_PaymentMethodName")
                .IsUnique();

            builder.Property(e => e.PaymentMethodID).ValueGeneratedNever();
            builder.Property(e => e.PaymentMethodName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 