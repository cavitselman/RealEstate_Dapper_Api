namespace RED.UI.DTOs.PropertyDetailDTOs
{
    public class CreatePropertyDetailDTO
    {
        public int BedRoomCount { get; set; }
        public int PropertySize { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public int PropertyID { get; set; }
    }
}
