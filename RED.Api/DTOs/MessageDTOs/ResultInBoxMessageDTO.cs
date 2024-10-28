namespace RED.Api.DTOs.MessageDTOs
{
    public class ResultInBoxMessageDTO
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string UserImageUrl { get; set; }
    }
}
