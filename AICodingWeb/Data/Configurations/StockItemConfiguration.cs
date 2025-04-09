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

            builder.HasOne(d => d.Color)
                .WithMany(p => p.StockItems)
                .HasForeignKey(d => d.ColorID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_ColorID");

            builder.HasOne(d => d.OuterPackage)
                .WithMany(p => p.StockItemsWithOuterPackage)
                .HasForeignKey(d => d.OuterPackageID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_OuterPackageID");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.StockItems)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_SupplierID");

            builder.HasOne(d => d.UnitPackage)
                .WithMany(p => p.StockItemsWithUnitPackage)
                .HasForeignKey(d => d.UnitPackageID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_StockItems_UnitPackageID");
        }
    }
} 