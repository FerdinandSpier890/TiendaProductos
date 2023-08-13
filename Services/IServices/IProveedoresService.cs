using TiendaProductos.Models.Dto;

namespace TiendaProductos.Services.IServices
{
    public interface IProveedoresService
    {
        Task<ResponseDto> GetAllSupplersAsync();
    }
}
