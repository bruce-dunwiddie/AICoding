using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class StockItem
    {
        public int StockItemID { get; set; }
        public string StockItemName { get; set; }
        public int SupplierID { get; set; }
        public int? ColorID { get; set; }
        public int UnitPackageID { get; set; }
        public int OuterPackageID { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        public string Barcode { get; set; }
        public decimal TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public string MarketingComments { get; set; }
        public string InternalComments { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }
        public string SearchDetails { get; set; }
        public int LastEditedBy { get; set; }
    }
} 