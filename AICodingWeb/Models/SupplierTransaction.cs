using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class SupplierTransaction
    {
        public int SupplierTransactionID { get; set; }
        public int SupplierID { get; set; }
        public int TransactionTypeID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int PaymentMethodID { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public bool IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
    }
} 