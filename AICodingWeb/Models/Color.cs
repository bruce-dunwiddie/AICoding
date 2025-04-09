using System;
using System.Collections.Generic;

namespace AICodingWeb.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual ICollection<StockItem> StockItems { get; set; }
    }
} 