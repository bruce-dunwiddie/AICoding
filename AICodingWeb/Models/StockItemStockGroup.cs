using System;

namespace AICodingWeb.Models
{
    public class StockItemStockGroup
    {
        public int StockItemStockGroupID { get; set; }
        public int StockItemID { get; set; }
        public int StockGroupID { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual StockItem StockItem { get; set; }
        public virtual StockGroup StockGroup { get; set; }
    }
} 