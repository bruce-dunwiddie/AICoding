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
            builder.Property(e => e.DeliveryLocation).HasColumnType("geography");
            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);
            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.PostalAddressLine1).HasMaxLength(60).IsRequired();
            builder.Property(e => e.PostalAddressLine2).HasMaxLength(60);
            builder.Property(e => e.PostalPostalCode).HasMaxLength(10).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            builder.HasOne(d => d.AlternateContactPerson)
                .WithMany(p => p.AlternateContactCustomers)
                .HasForeignKey(d => d.AlternateContactPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_AlternateContactPersonID");

            builder.HasOne(d => d.BillToCustomer)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.BillToCustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_BillToCustomerID");

            builder.HasOne(d => d.CustomerCategory)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerCategoryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_CustomerCategoryID");

            builder.HasOne(d => d.DeliveryMethod)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.DeliveryMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_DeliveryMethodID");

            builder.HasOne(d => d.DeliveryCity)
                .WithMany(p => p.DeliveryCustomers)
                .HasForeignKey(d => d.DeliveryCityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_DeliveryCityID");

            builder.HasOne(d => d.PostalCity)
                .WithMany(p => p.PostalCustomers)
                .HasForeignKey(d => d.PostalCityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_PostalCityID");

            builder.HasOne(d => d.PrimaryContactPerson)
                .WithMany(p => p.PrimaryContactCustomers)
                .HasForeignKey(d => d.PrimaryContactPersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Customers_PrimaryContactPersonID");
        }
    }
} 