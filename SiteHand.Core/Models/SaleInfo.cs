namespace SiteHand.Core.Models
{
    public class SaleInfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
        public string buyLink { get; set; }
        public RetailPrice retailPrice { get; set; }
    }
}
