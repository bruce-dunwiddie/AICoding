using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AICodingWeb.Models;
using AICodingWeb.Data.Configurations;

namespace AICodingWeb.Data
{
    public class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options)
            : base(options)
        {
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<SupplierCategory> SupplierCategories { get; set; }
        public DbSet<SupplierTransaction> SupplierTransactions { get; set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockItemTransaction> StockItemTransactions { get; set; }
        public DbSet<StockItemStockGroup> StockItemStockGroups { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<SpecialDeal> SpecialDeals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations
            modelBuilder.ApplyConfiguration(new StateProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryMethodConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new StockItemTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceLineConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialDealConfiguration());
            modelBuilder.ApplyConfiguration(new StockItemConfiguration());
            modelBuilder.ApplyConfiguration(new StockItemStockGroupConfiguration());
            modelBuilder.ApplyConfiguration(new StockGroupConfiguration());
            modelBuilder.ApplyConfiguration(new PackageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
        }
    }
} 