using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AICodingWeb.Models;

namespace AICodingWeb.Data.Configurations
{
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.ToTable("StockItems", "Warehouse");

            builder.HasIndex(e => e.ColorID)
                .HasDatabaseName("FK_Warehouse_StockItems_ColorID");

            builder.HasIndex(e => e.OuterPackageID)
                .HasDatabaseName("FK_Warehouse_StockItems_OuterPackageID");

            builder.HasIndex(e => e.UnitPackageID)
                .HasDatabaseName("FK_Warehouse_StockItems_UnitPackageID");

            builder.HasIndex(e => e.StockItemName)
                .HasDatabaseName("UQ_Warehouse_StockItems_StockItemName")
                .IsUnique();

            builder.Property(e => e.StockItemID).ValueGeneratedNever();
            builder.Property(e => e.StockItemName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.SupplierID).IsRequired();
            builder.Property(e => e.ColorID);
            builder.Property(e => e.UnitPackageID).IsRequired();
            builder.Property(e => e.OuterPackageID).IsRequired();
            builder.Property(e => e.Brand).HasMaxLength(50);
            builder.Property(e => e.Size).HasMaxLength(20);
            builder.Property(e => e.LeadTimeDays).IsRequired();
            builder.Property(e => e.QuantityPerOuter).IsRequired();
            builder.Property(e => e.IsChillerStock).IsRequired();
            builder.Property(e => e.Barcode).HasMaxLength(50);
            builder.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.RecommendedRetailPrice).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.TypicalWeightPerUnit).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(e => e.MarketingComments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.InternalComments).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Photo).HasColumnType("varbinary(max)");
            builder.Property(e => e.CustomFields).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Tags).HasColumnType("nvarchar(max)");
            builder.Property(e => e.SearchDetails).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.LastEditedBy).IsRequired();

            // Configure relationships
            builder.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(si => si.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Color>()
                .WithMany()
                .HasForeignKey(si => si.ColorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PackageType>()
                .WithMany()
                .HasForeignKey(si => si.UnitPackageID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PackageType>()
                .WithMany()
                .HasForeignKey(si => si.OuterPackageID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 