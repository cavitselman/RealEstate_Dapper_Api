using Dapper;
using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.LoginDTOs;
using RED.Api.Models.DapperContext;
using RED.Api.Tools;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDTO loginDTO)
        {
            string query = "Select * From AppUser Where Username=@username and Password=@password";
            string query2 = "Select UserId From AppUser Where Username=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDTO.Username);
            parameters.Add("@password", loginDTO.Password);
            using(var connection=_context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDTO>(query, parameters);
                var values2=await connection.QueryFirstAsync<GetAppUserIdDTO>(query2, parameters);
                if(values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
