using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class StockGroup
    {
        public int StockGroupID { get; set; }
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
    }
} 