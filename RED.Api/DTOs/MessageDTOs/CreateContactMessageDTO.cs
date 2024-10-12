namespace RED.Api.DTOs.MessageDTOs
{
    public class CreateContactMessageDTO
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
