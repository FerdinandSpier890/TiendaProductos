using TiendaProductos.Models.Dto;

namespace TiendaProductos.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);

        Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);

        Task<ResponseDto> AssingRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
