using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class StateProvince
    {
        public int StateProvinceID { get; set; }
        public string StateProvinceCode { get; set; }
        public string StateProvinceName { get; set; }
        public int CountryID { get; set; }
        public string SalesTerritory { get; set; }
        public string Border { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
} 