using System;

namespace AICodingWeb.Models
{
    public class StockItemTransaction
    {
        public int StockItemTransactionID { get; set; }
        public int StockItemID { get; set; }
        public int TransactionTypeID { get; set; }
        public int? CustomerID { get; set; }
        public int? InvoiceID { get; set; }
        public int? SupplierID { get; set; }
        public int? PurchaseOrderID { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual StockItem StockItem { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
} 