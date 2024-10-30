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

        [HttpPost("SignIn")]
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateRegisterDTO registerDTO)
        {
            try
            {
                // Kullanıcı adı ve şifreyi kontrol et
                if (string.IsNullOrWhiteSpace(registerDTO.Username) || string.IsNullOrWhiteSpace(registerDTO.Password))
                {
                    return BadRequest("Kullanıcı adı ve şifre boş olamaz.");
                }

                // Şifreyi düz metin olarak al
                string plainPassword = registerDTO.Password;

                // Kullanıcı eklemek için SQL sorgusu
                string query = "INSERT INTO AppUser (Username, Password, UserRole, Email, Name, PhoneNumber, UserImageUrl) VALUES (@username, @password, @userRole, @Email, @Name, @PhoneNumber, @UserImageUrl)";

                var parameters = new DynamicParameters();
                parameters.Add("@username", registerDTO.Username);
                parameters.Add("@password", plainPassword);
                parameters.Add("@userRole", 2); // 'User' rolü için sayısal değer (örneğin, 2)
                parameters.Add("@Email", registerDTO.Email);
                parameters.Add("@Name", registerDTO.Name);
                parameters.Add("@PhoneNumber", registerDTO.PhoneNumber);
                parameters.Add("@UserImageUrl", registerDTO.UserImageUrl);

                using (var connection = _context.CreateConnection())
                {
                    // Kullanıcının zaten var olup olmadığını kontrol et
                    var existingUser = await connection.QueryFirstOrDefaultAsync<CreateLoginDTO>(
                        "SELECT * FROM AppUser WHERE Username = @username",
                        new { username = registerDTO.Username });

                    if (existingUser != null)
                    {
                        return Conflict("Bu kullanıcı adı zaten alınmış.");
                    }

                    // Yeni kullanıcıyı veritabanına ekle
                    await connection.ExecuteAsync(query, parameters);

                    // Kullanıcı bilgileri ile token oluştur
                    var userViewModel = new GetCheckAppUserViewModel
                    {
                        Username = registerDTO.Username,
                        Id = 0, // Bu değeri güncellemeyi unutmayın
                        Role = "User" // Varsayılan rol
                    };

                    var tokenResponse = JwtTokenGenerator.GenerateToken(userViewModel);

                    return Ok(new { Message = "Kayıt başarılı.", Token = tokenResponse.Token });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }
    }
}
