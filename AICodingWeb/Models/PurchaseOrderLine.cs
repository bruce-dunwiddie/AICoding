using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int StockItemID { get; set; }
        public int PackageTypeID { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; }
        public DateTime ExpectedUnitPricePerOuter { get; set; }
        public decimal? ReceivedOuters { get; set; }
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
    }
} 