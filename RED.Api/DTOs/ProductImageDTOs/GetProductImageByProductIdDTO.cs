namespace RED.Api.DTOs.ProductImageDTOs
{
    public class GetProductImageByProductIdDTO
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
