using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class SpecialDeal
    {
        public int SpecialDealID { get; set; }
        public int? StockItemID { get; set; }
        public int? CustomerID { get; set; }
        public int? BuyingGroupID { get; set; }
        public int? CustomerCategoryID { get; set; }
        public int? StockGroupID { get; set; }
        public string DealDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
    }
} 