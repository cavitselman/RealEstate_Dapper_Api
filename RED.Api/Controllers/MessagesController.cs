using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.MessageDTOs;
using RED.Api.Repositories.MessageRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInBoxLast3MessageListByReceiver(int id)
        {
            var values = await _messageRepository.GetInBoxLast3MessageListByReceiver(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactMessageDTO createContactMessageDTO)
        {
            await _messageRepository.SendMessage(createContactMessageDTO);
            return Ok("Mesaj başarıyla gönderildi.");
        }
    }
}
