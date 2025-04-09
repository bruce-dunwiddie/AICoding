using System;

namespace AICodingWeb.Models
{
    public class SpecialDeal
    {
        public int SpecialDealID { get; set; }
        public int? StockItemID { get; set; }
        public int? CustomerID { get; set; }
        public int? BuyingGroupID { get; set; }
        public int? CustomerCategoryID { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual StockItem StockItem { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
    }
} 