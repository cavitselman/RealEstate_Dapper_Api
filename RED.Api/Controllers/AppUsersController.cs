using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.AppUserDTOs;
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

        [HttpGet("GetAppUserInfo")]
        public async Task<IActionResult> GetAppUserInfo(int id)
        {
            var value = await _appUserRepository.GetAppUserInfo(id);
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserWithLast3Properties(int id)
        {
            var value = await _appUserRepository.GetAppUserWithLast3Properties(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            await _appUserRepository.DeleteAppUser(id);
            return Ok("Kullanıcı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(GetAppUserInfoDTO getAppUserInfoDTO)
        {
            await _appUserRepository.UpdateAppUser(getAppUserInfoDTO);
            return Ok("Kullanıcı Başarıyla Güncellendi");
        }

        [HttpPut("UpdateAppUserRole")]
        public async Task<IActionResult> UpdateAppUserRole(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            await _appUserRepository.UpdateAppUserRole(updateAppUserRoleDTO);
            return Ok("Rol Başarıyla Güncellendi");
        }

        [HttpGet("GetAppUserRole")]
        public async Task<IActionResult> GetAppUserRole()
        {
            var value = await _appUserRepository.GetAppUserRole();
            return Ok(value);
        }
        
        [HttpGet("GetAppUserRoleId")]
        public async Task<IActionResult> GetAppUserRoleId(int id)
        {
            var value = await _appUserRepository.GetAppUserRoleId(id);
            return Ok(value);
        }
    }
}
