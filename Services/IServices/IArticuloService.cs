using TiendaProductos.Models.Dto;

namespace TiendaProductos.Services.IServices
{
    public interface IArticuloService
    {
        Task<ResponseDto> GetAllArticleBySupplersAsync(Guid id_proveedor);
    }
}
