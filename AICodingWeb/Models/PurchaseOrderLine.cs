using System;

namespace AICodingWeb.Models
{
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int StockItemID { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; }
        public DateTime ReceivedOuters { get; set; }
        public int PackageTypeID { get; set; }
        public decimal ExpectedUnitPricePerOuter { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual StockItem StockItem { get; set; }
        public virtual PackageType PackageType { get; set; }
    }
} 