using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.AppUserRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUserByPropertyId(int id)
        {
            var value = await _appUserRepository.GetAppUserByPropertyId(id);
            return Ok(value);
        }
    }
}
