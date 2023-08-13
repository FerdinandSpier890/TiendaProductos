using TiendaProductos.Services.IServices;
using TiendaProductos.Utility;

namespace TiendaProductos.Services
{
    public class TokenProviderService : ITokenProviderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenProviderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }   

        // Método que se encarga de eliminar una cookie y un token de una peticion http
        public void ClearToken()
        {
            _httpContextAccessor.HttpContext?.
                Response.Cookies.Delete(SD.TokenCookie);
        }

        // Este método se encarga de obtener el token de una peticion http valida
        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = _httpContextAccessor.HttpContext?.
                Request.Cookies.TryGetValue(SD.TokenCookie, out token);

            return hasToken is true ? token : null;
        }

        // Este método se encarga de recibir el token de una solicitud http
        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext?.
                Response.Cookies.Append(SD.TokenCookie, token);
        }

    }
}
