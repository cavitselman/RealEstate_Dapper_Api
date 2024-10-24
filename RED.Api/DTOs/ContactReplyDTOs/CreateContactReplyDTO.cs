namespace RED.Api.DTOs.ContactReplyDTOs
{
    public class CreateContactReplyDTO
    {
        public string Email { get; set; }
        public int ContactID { get; set; }
        public string SenderEmail { get; set; }
        public string Reply { get; set; }
        public DateTime Date { get; set; }
    }
}
