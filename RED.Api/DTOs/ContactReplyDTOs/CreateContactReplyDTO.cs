namespace RED.Api.DTOs.ContactReplyDTOs
{
    public class CreateContactReplyDTO
    {
        public string Email { get; set; }
        public int ContactId { get; set; }
        public string ReceiverEmail { get; set; }
        public string Reply { get; set; }
        public DateTime Date { get; set; }
    }
}
