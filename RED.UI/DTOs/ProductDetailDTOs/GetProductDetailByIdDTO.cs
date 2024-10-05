namespace RED.UI.DTOs.ProductDetailDTOs
{
    public class GetProductDetailByIdDTO
    {
            public int productDetailId { get; set; }
            public int bedRoomCount { get; set; }
            public int productSize { get; set; }
            public int bathCount { get; set; }
            public int roomCount { get; set; }
            public int garageSize { get; set; }
            public string buildYear { get; set; }
            public decimal price { get; set; }
            public string location { get; set; }
            public string videoUrl { get; set; }
            public int productId { get; set; }
            public DateTime advertisementDate { get; set; }
    }
}
