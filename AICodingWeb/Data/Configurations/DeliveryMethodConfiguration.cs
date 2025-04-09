using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods", "Application");

            builder.HasIndex(e => e.DeliveryMethodName)
                .HasDatabaseName("UQ_Application_DeliveryMethods_DeliveryMethodName")
                .IsUnique();

            builder.Property(e => e.DeliveryMethodID).ValueGeneratedNever();
            builder.Property(e => e.DeliveryMethodName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 