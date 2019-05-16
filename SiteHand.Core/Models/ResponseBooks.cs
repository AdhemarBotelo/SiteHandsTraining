using System;
using System.Collections.Generic;
using System.Text;

namespace SiteHand.Core.Models
{
    public class ResponseBooks
    {
        public string kind { get; set; }
        public long totalItems { get; set; }
        public IList<Volume> items { get; set; }
    }
}
