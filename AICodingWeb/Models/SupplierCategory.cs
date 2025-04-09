using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class SupplierCategory
    {
        public int SupplierCategoryID { get; set; }
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
} 