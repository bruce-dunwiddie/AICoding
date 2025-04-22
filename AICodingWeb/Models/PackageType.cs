using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class PackageType
    {
        public int PackageTypeID { get; set; }
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }

        public virtual ICollection<StockItem> StockItemsWithUnitPackage { get; set; }
        public virtual ICollection<StockItem> StockItemsWithOuterPackage { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
} 