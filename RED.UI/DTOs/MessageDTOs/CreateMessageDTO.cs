namespace RED.UI.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }   
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
