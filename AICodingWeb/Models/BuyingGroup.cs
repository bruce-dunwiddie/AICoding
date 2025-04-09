using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class BuyingGroup
    {
        public int BuyingGroupID { get; set; }
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
} 