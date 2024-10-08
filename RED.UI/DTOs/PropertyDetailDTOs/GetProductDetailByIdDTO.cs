namespace RED.UI.DTOs.PropertyDetailDTOs
{
    public class GetPropertyDetailByIdDTO
    {
            public int PropertyDetailId { get; set; }
            public int bedRoomCount { get; set; }
            public int PropertySize { get; set; }
            public int bathCount { get; set; }
            public int roomCount { get; set; }
            public int garageSize { get; set; }
            public string buildYear { get; set; }
            public decimal price { get; set; }
            public string location { get; set; }
            public string videoUrl { get; set; }
            public int PropertyId { get; set; }
            public DateTime advertisementDate { get; set; }
    }
}
