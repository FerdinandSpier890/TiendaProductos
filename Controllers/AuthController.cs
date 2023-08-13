using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TiendaProductos.Models.Dto;
using TiendaProductos.Services.IServices;
using GoogleReCaptcha;

namespace TiendaProductos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProviderService _tokenProviderService;

        public AuthController(IAuthService authService, ITokenProviderService tokenProviderService)
        {
            _authService = authService;
            _tokenProviderService = tokenProviderService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);
            
            if(responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Data));

                // Almacenar el nombre de usuario en ViewBag o ViewData
                ViewBag.UserName = loginRequestDto.UserName;

                await SignInUser(loginResponseDto);
                _tokenProviderService.SetToken(loginResponseDto.Token);
                
                // Agregar el mensaje de bienvenida al TempData
                TempData["WelcomeMessage"] = "¡Bienvenido, " + loginRequestDto.UserName + "!";
                
                // Redireccionar a la vista de Login (para mostrar el Toastr)
                return RedirectToAction("Login");

            }
            else
            {
                
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(loginRequestDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegistrationRequestDto registrationRequestDto = new();
            return View(registrationRequestDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProviderService.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            // Creamos una variable para el manejador de los Tokens
            var handler = new JwtSecurityTokenHandler();

            // Creamos una variable para leer el token
            var jwt = handler.ReadJwtToken(loginResponseDto.Token);

            //Establecemos el esquema de autenticación
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            // Agregamos los claims del token solicitado a la API
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            // Agregamos los claims del token solicitado a la API
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));

            // Agregamos los claims del token solicitado a la API
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            // Agregamos los claims del token solicitado a la API
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            //Almacenamos todas los claims dentro de principal
            var principal = new ClaimsPrincipal(identity);

            // Asociamos el cxontexto con el claims principal
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
