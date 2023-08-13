using TiendaProductos.Models.Dto;

namespace TiendaProductos.Services.IServices
{
    public interface IBaseService
    { 
        Task<ResponseDto> SendAsync(RequestDto requestDto);

        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
