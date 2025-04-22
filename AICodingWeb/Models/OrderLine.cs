using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public int PackageTypeID { get; set; }
        public int Quantity { get; set; }
        public int PickedQuantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int LastEditedBy { get; set; }
    }
} 