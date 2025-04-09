using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class CustomerCategory
    {
        public int CustomerCategoryID { get; set; }
        public string CustomerCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
} 