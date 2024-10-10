namespace RED.Api.DTOs.PropertyDTOs
{
    public class CreatePropertyDTO
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public bool PropertyStatus { get; set; }
        public int PropertyCategory { get; set; }
        public int AppUserId { get; set; }
    }
}
