using System;
using System.Collections.Generic;
using System.Text;

namespace SiteHand.Core.Models
{
    public class Volume
    {
        public string Kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public string selfLing { get; set; }
        public VolumeInfo volumeInfo { get; set; }
        public SaleInfo saleInfo { get; set; }
    }

    public enum PrintType
    {
        all,
        books,
        magazines
    }
}
