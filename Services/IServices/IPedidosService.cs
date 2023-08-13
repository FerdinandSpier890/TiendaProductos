using TiendaProductos.Models.Dto;

namespace TiendaProductos.Services.IServices
{
    public interface IPedidosService
    {
        Task<ResponseDto> GetAllPedidos();
    }
}
