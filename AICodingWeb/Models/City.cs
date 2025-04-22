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
    }
} 