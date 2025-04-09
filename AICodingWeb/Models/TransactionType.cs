using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class TransactionType
    {
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
} 