using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int StateProvinceID { get; set; }
        public string Location { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<Customer> DeliveryCustomers { get; set; }
        public virtual ICollection<Customer> PostalCustomers { get; set; }
        public virtual ICollection<Supplier> DeliverySuppliers { get; set; }
        public virtual ICollection<Supplier> PostalSuppliers { get; set; }
    }
} 