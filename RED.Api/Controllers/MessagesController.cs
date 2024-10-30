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
        public async Task<IActionResult> SendMessage(CreateMessageDTO createContactMessageDTO)
        {
            await _messageRepository.SendMessage(createContactMessageDTO);
            return Ok("Mesaj başarıyla gönderildi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageRepository.DeleteMessage(id);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("GetInBoxByReceiver")]
        public async Task<IActionResult> GetInBoxByReceiver(int id)
        {
            var values = await _messageRepository.GetInBoxByReceiver(id);
            return Ok(values);
        }

        [HttpGet("GetInBoxBySender")]
        public async Task<IActionResult> GetInBoxBySender(int id)
        {
            var values = await _messageRepository.GetInBoxBySender(id);
            return Ok(values);
        }

        [HttpGet("GetInBoxDetailByReceiver")]
        public async Task<IActionResult> GetInBoxDetailByReceiver(int id)
        {
            var values = await _messageRepository.GetInBoxDetailByReceiver(id);
            return Ok(values);
        }

        [HttpGet("GetUserIdByEmail")]
        public async Task<IActionResult> GetUserIdByEmail(string email)
        {
            var values = await _messageRepository.GetUserIdByEmail(email);
            return Ok(values);
        }

    }
}
