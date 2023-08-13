using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TiendaProductos.Models.Dto;
using TiendaProductos.Services.IServices;

namespace TiendaProductos.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProviderService _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProviderService tokenProviderService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProviderService;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("PedidosApi");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token
                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content =
                        new StringContent(JsonConvert.SerializeObject(requestDto.Data),
                        System.Text.Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false,
                };
                return dto;
            }
        }


        // Método para enviar solicitudes HTTP a una API externa y recibir una respuesta
        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                // Crear una instancia de HttpClient utilizando la configuración llamada "PedidosApi"
                HttpClient client = _httpClientFactory.CreateClient("PedidosApi");

                // Crear una nueva solicitud HTTP
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                // Si se pasa "withBearer" como true, se incluirá un token de autenticación en la cabecera de la solicitud
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    // Agregar el token a la cabecera de la solicitud utilizando la especificación "Bearer"
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                // Establecer la dirección URL de la solicitud utilizando la URL proporcionada en "requestDto.Url"
                message.RequestUri = new Uri(requestDto.Url);

                // Si la solicitud contiene datos, agregarlos al cuerpo de la solicitud en formato JSON
                if (requestDto.Data != null)
                {
                    message.Content =
                        new StringContent(JsonConvert.SerializeObject(requestDto.Data),
                        System.Text.Encoding.UTF8, "application/json");
                }

                // Realizar la solicitud HTTP según el tipo especificado en "requestDto.ApiType"
                HttpResponseMessage apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    default:
                        // Si no se especifica un tipo válido, se asume una solicitud GET
                        message.Method = HttpMethod.Get;
                        break;
                }

                // Enviar la solicitud HTTP al servidor externo y recibir la respuesta
                apiResponse = await client.SendAsync(message);

                // Evaluar el código de estado de la respuesta para determinar el resultado de la solicitud
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        // Si la respuesta tiene un código de estado válido, leer el contenido de la respuesta y deserializarlo en un objeto ResponseDto
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                // Si se produce una excepción durante el proceso, crear un objeto ResponseDto con un mensaje de error y marcarlo como no exitoso
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false,
                };
                return dto;
            }
        }

    }
}
