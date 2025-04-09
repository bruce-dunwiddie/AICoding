using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
} 