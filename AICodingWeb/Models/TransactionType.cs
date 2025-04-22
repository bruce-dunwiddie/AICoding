using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class TransactionType
    {
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
    }
} 