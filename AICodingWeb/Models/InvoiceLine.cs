using System;

namespace AICodingWeb.Models
{
    public class InvoiceLine
    {
        public int InvoiceLineID { get; set; }
        public int InvoiceID { get; set; }
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public int PackageTypeID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LineProfit { get; set; }
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual StockItem StockItem { get; set; }
        public virtual PackageType PackageType { get; set; }
    }
} 