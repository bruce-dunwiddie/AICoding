using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string FormalName { get; set; }
        public string IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        public string CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Border { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
} 