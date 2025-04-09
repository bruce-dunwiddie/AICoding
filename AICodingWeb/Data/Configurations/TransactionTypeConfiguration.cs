using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("TransactionTypes", "Application");

            builder.HasIndex(e => e.TransactionTypeName)
                .HasDatabaseName("UQ_Application_TransactionTypes_TransactionTypeName")
                .IsUnique();

            builder.Property(e => e.TransactionTypeID).ValueGeneratedNever();
            builder.Property(e => e.TransactionTypeName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();
        }
    }
} 