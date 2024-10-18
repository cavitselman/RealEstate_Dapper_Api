using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.ContactReplyDTOs;
using RED.Api.Repositories.ContactReplyRepositories;
using RED.Api.Repositories.ContactRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRepliesController : ControllerBase
    {
        private readonly IContactReplyRepository _contactReplyRepository;

        public ContactRepliesController(IContactReplyRepository contactReplyRepository)
        {
            _contactReplyRepository = contactReplyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostReply(CreateContactReplyDTO createContactReplyDTO)
        {
            await _contactReplyRepository.PostReply(createContactReplyDTO);
            return Ok("Cevap başarıyla gönderildi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReply(int id)
        {
            var value = await _contactReplyRepository.GetReply(id);
            return Ok(value);
        }
    }
}
