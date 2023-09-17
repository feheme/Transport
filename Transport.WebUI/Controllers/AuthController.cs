using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Transport.WebUI.Models.AuthViewModel;
using Transport.WebUI.Models.ReservationViewModel;

namespace Transport.WebUI.Controllers
{
  
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // HttpClient ile API'ye istek gönderin
            var httpClient = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(loginViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7100/api/Auths/login", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var accessToken = await response.Content.ReadAsStringAsync();
                var tokenObject = JObject.Parse(accessToken);
                var tokenNew = tokenObject["token"].Value<string>();

                // Token içindeki rolleri al
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(tokenNew);
                var roles = token.Claims
                                .Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value)
                                .ToList();

                // Kullanıcı rollerini kontrol et
                if (roles.Contains("Admin"))
                {
                    // Admin ise yönlendir
                    return RedirectToAction("AdminDashboard");
                }
                else if (roles.Contains("User"))
                {
                    // User ise yönlendir
                    return RedirectToAction("AddReservation", "Reservation");
                }
                else
                {
                    // Yetkilendirme hatası
                    ModelState.AddModelError(string.Empty, "Kimlik doğrulama başarısız.");
                    return View(loginViewModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kimlik doğrulama başarısız.");
                return View(loginViewModel);
            }
        }
    }
}
