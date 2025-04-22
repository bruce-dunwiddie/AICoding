using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Purchasing");

            builder.HasIndex(e => e.SupplierName)
                .HasDatabaseName("UQ_Purchasing_Suppliers_SupplierName")
                .IsUnique();

            builder.HasIndex(e => e.AlternateContactPersonID)
                .HasDatabaseName("FK_Purchasing_Suppliers_AlternateContactPersonID");

            builder.HasIndex(e => e.DeliveryMethodID)
                .HasDatabaseName("FK_Purchasing_Suppliers_DeliveryMethodID");

            builder.HasIndex(e => e.PostalCityID)
                .HasDatabaseName("FK_Purchasing_Suppliers_PostalCityID");

            builder.HasIndex(e => e.PrimaryContactPersonID)
                .HasDatabaseName("FK_Purchasing_Suppliers_PrimaryContactPersonID");

            builder.HasIndex(e => e.SupplierCategoryID)
                .HasDatabaseName("FK_Purchasing_Suppliers_SupplierCategoryID");

            builder.Property(e => e.SupplierID).ValueGeneratedNever();
            builder.Property(e => e.SupplierName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.SupplierCategoryID).IsRequired();
            builder.Property(e => e.PrimaryContactPersonID).IsRequired();
            builder.Property(e => e.DeliveryMethodID).IsRequired();
            builder.Property(e => e.DeliveryCityID).IsRequired();
            builder.Property(e => e.PostalCityID).IsRequired();
            builder.Property(e => e.SupplierReference).HasMaxLength(20);
            builder.Property(e => e.BankAccountName).HasMaxLength(50);
            builder.Property(e => e.BankAccountBranch).HasMaxLength(50);
            builder.Property(e => e.BankAccountCode).HasMaxLength(20);
            builder.Property(e => e.BankAccountNumber).HasMaxLength(20);
            builder.Property(e => e.BankInternationalCode).HasMaxLength(50);
            builder.Property(e => e.PaymentDays).HasMaxLength(20);
            builder.Property(e => e.InternalComments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);
            builder.Property(e => e.FaxNumber).HasMaxLength(20);
            builder.Property(e => e.WebsiteURL).HasMaxLength(2083);
            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.DeliveryLocation).HasColumnType("geography");
            builder.Property(e => e.PostalAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.PostalAddressLine2).HasMaxLength(60);
            builder.Property(e => e.PostalPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<SupplierCategory>()
                .WithMany()
                .HasForeignKey(s => s.SupplierCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(s => s.PrimaryContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(s => s.AlternateContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<DeliveryMethod>()
                .WithMany()
                .HasForeignKey(s => s.DeliveryMethodID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(s => s.DeliveryCityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(s => s.PostalCityID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 