namespace RED.UI.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
