using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
    }
} 