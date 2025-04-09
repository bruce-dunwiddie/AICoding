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

            builder.HasOne(d => d.BuyingGroup)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.BuyingGroupID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SpecialDeals_BuyingGroupID");

            builder.HasOne(d => d.CustomerCategory)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.CustomerCategoryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SpecialDeals_CustomerCategoryID");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SpecialDeals_CustomerID");

            builder.HasOne(d => d.StockItem)
                .WithMany(p => p.SpecialDeals)
                .HasForeignKey(d => d.StockItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SpecialDeals_StockItemID");
        }
    }
} 