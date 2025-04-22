using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Sales");

            builder.HasIndex(e => e.AlternateContactPersonID)
                .HasDatabaseName("FK_Sales_Customers_AlternateContactPersonID");

            builder.HasIndex(e => e.BillToCustomerID)
                .HasDatabaseName("FK_Sales_Customers_BillToCustomerID");

            builder.HasIndex(e => e.CustomerCategoryID)
                .HasDatabaseName("FK_Sales_Customers_CustomerCategoryID");

            builder.HasIndex(e => e.DeliveryMethodID)
                .HasDatabaseName("FK_Sales_Customers_DeliveryMethodID");

            builder.HasIndex(e => e.DeliveryCityID)
                .HasDatabaseName("FK_Sales_Customers_DeliveryCityID");

            builder.HasIndex(e => e.PostalCityID)
                .HasDatabaseName("FK_Sales_Customers_PostalCityID");

            builder.HasIndex(e => e.PrimaryContactPersonID)
                .HasDatabaseName("FK_Sales_Customers_PrimaryContactPersonID");

            builder.HasIndex(e => e.CustomerName)
                .HasDatabaseName("UQ_Sales_Customers_CustomerName")
                .IsUnique();

            builder.Property(e => e.CustomerID).ValueGeneratedNever();
            builder.Property(e => e.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.BillToCustomerID).IsRequired();
            builder.Property(e => e.CustomerCategoryID).IsRequired();
            builder.Property(e => e.BuyingGroupID);
            builder.Property(e => e.PrimaryContactPersonID).IsRequired();
            builder.Property(e => e.AlternateContactPersonID);
            builder.Property(e => e.DeliveryMethodID).IsRequired();
            builder.Property(e => e.DeliveryCityID).IsRequired();
            builder.Property(e => e.PostalCityID).IsRequired();
            builder.Property(e => e.CreditLimit);
            builder.Property(e => e.AccountOpenedDate).IsRequired();
            builder.Property(e => e.StandardDiscountPercentage).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(e => e.IsStatementSent).IsRequired();
            builder.Property(e => e.IsOnCreditHold).IsRequired();
            builder.Property(e => e.PaymentDays).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(e => e.FaxNumber).HasMaxLength(20).IsRequired();
            builder.Property(e => e.DeliveryRun).HasMaxLength(5);
            builder.Property(e => e.RunPosition).HasMaxLength(5);
            builder.Property(e => e.WebsiteURL).HasMaxLength(256).IsRequired();
            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.PostalAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.PostalAddressLine2).HasMaxLength(60);
            builder.Property(e => e.PostalPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(c => c.BillToCustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<CustomerCategory>()
                .WithMany()
                .HasForeignKey(c => c.CustomerCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<BuyingGroup>()
                .WithMany()
                .HasForeignKey(c => c.BuyingGroupID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(c => c.PrimaryContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey(c => c.AlternateContactPersonID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<DeliveryMethod>()
                .WithMany()
                .HasForeignKey(c => c.DeliveryMethodID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(c => c.DeliveryCityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>()
                .WithMany()
                .HasForeignKey(c => c.PostalCityID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 