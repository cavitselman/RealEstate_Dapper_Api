namespace RED.UI.DTOs.AppUserDTOs
{
    public class GetAppUserByPropertyIdDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImageUrl { get; set; }
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}
