using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class StockItemStockGroup
    {
        public int StockItemStockGroupID { get; set; }
        public int StockItemID { get; set; }
        public int StockGroupID { get; set; }
        public int LastEditedBy { get; set; }
    }
} 