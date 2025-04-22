using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class SpecialDealConfiguration : IEntityTypeConfiguration<SpecialDeal>
    {
        public void Configure(EntityTypeBuilder<SpecialDeal> builder)
        {
            builder.ToTable("SpecialDeals", "Sales");

            builder.HasIndex(e => e.BuyingGroupID)
                .HasDatabaseName("FK_Sales_SpecialDeals_BuyingGroupID");

            builder.HasIndex(e => e.CustomerCategoryID)
                .HasDatabaseName("FK_Sales_SpecialDeals_CustomerCategoryID");

            builder.HasIndex(e => e.CustomerID)
                .HasDatabaseName("FK_Sales_SpecialDeals_CustomerID");

            builder.HasIndex(e => e.StockItemID)
                .HasDatabaseName("FK_Sales_SpecialDeals_StockItemID");

            builder.Property(e => e.SpecialDealID).ValueGeneratedNever();
            builder.Property(e => e.StockItemID);
            builder.Property(e => e.CustomerID);
            builder.Property(e => e.BuyingGroupID);
            builder.Property(e => e.CustomerCategoryID);
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<BuyingGroup>()
                .WithMany()
                .HasForeignKey(d => d.BuyingGroupID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<CustomerCategory>()
                .WithMany()
                .HasForeignKey(d => d.CustomerCategoryID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<StockItem>()
                .WithMany()
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
} 