using RED.UI.DTOs.ContactDTOs;
using RED.UI.DTOs.ContactReplyDTOs;

namespace RED.UI.Models
{
    public class ContactDetailViewModel
    {
        public CreateContactReplyDTO ReplyDTO { get; set; }
        public GetByIDContactDTO ContactDetails { get; set; }
        public List<GetByIDContactReplyDTO> Replies { get; set; }

        public ContactDetailViewModel()
        {
            Replies = new List<GetByIDContactReplyDTO>(); // Boş bir liste ile başlat
        }
    }
}
