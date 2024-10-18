namespace RED.UI.DTOs.PropertyDTOs
{
    public class ResultPropertyDTO
    {
        public int PropertyID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryName { get; set; }
        public string coverimage { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public string SlugUrl { get; set; }
        public bool dealOfTheDay { get; set; }
        public bool PropertyStatus { get; set; }
        public DateTime advertisementDate { get; set; }
    }
}
