namespace RED.UI.DTOs.ContactReplyDTOs
{
    public class GetByIDContactReplyDTO
    {
        public int ReplyId { get; set; }
        public string Email { get; set; }
        public int ContactID { get; set; }
        public string SenderEmail { get; set; }
        public string Reply { get; set; }
        public DateTime Date { get; set; }
    }
}
