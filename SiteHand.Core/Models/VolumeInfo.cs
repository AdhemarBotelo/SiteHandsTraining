namespace SiteHand.Core.Models
{
    public class VolumeInfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }

        private string _description;

        public string description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                {
                    return _description;
                }
                else
                {
                    // regex which match html tags
                    System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("<[^>]*>");
                    // replace all matches with empty strin
                    _description = rx.Replace(_description, "");
                    return _description;
                }

            }
            set { _description = value; }
        }

        public int pageCount { get; set; }
        public string printType { get; set; }
        public string[] categories { get; set; }
        public string language { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public ImageLinks imageLinks { get; set; }
    }
}
