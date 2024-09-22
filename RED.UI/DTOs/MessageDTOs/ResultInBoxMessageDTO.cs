﻿namespace RED.UI.DTOs.MessageDTOs
{
    public class ResultInBoxMessageDTO
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string UserImageUrl { get; set; }
    }
}