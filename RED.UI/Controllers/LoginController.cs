using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RED.UI.DTOs.LoginDTOs;
using RED.UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RED.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDTO createLoginDTO, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(createLoginDTO); // Model hatalıysa geri döner
            }

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDTO), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44383/api/Login/SignIn", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel?.Token != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("realestatetoken", tokenModel.Token));

                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                    // Giriş yaptıktan sonra returnUrl varsa oraya yönlendir
                    return string.IsNullOrEmpty(returnUrl)
                        ? RedirectToAction("Index", "Dashboard", new { area = "EstateAgent" })
                        : Redirect(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
            return View(createLoginDTO);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterDTO createRegisterDTO)
        {
            if (string.IsNullOrWhiteSpace(createRegisterDTO.Username) ||
                string.IsNullOrWhiteSpace(createRegisterDTO.Password) ||
                string.IsNullOrWhiteSpace(createRegisterDTO.ConfirmPassword))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı, şifre ve onay şifresi boş olamaz.");
                return View(createRegisterDTO);
            }

            if (createRegisterDTO.Password != createRegisterDTO.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Şifreler eşleşmiyor.");
                return View(createRegisterDTO);
            }

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createRegisterDTO), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44383/api/Login/Register", content);

            if (response.IsSuccessStatusCode)
            {
                var loginDTO = new CreateLoginDTO
                {
                    Username = createRegisterDTO.Username,
                    Password = createRegisterDTO.Password
                };

                var loginContent = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
                var loginResponse = await client.PostAsync("https://localhost:44383/api/Login/SignIn", loginContent);

                if (loginResponse.IsSuccessStatusCode)
                {
                    var jsonData = await loginResponse.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Token))
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claims = token.Claims.ToList();

                        claims.Add(new Claim("realestatetoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Token alınamadı.");
                    }
                }
                else
                {
                    var errorMessage = await loginResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View(createRegisterDTO);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
