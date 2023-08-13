using TiendaProductos.Models.Dto;
using TiendaProductos.Services.IServices;

namespace TiendaProductos.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IBaseService _baseService;

        public ArticuloService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetAllArticleBySupplersAsync(Guid id_proveedor)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Data = null,
                Url = Utility.SD.ProveedoresApiBase + "/api/Articulos?proveedorId=" + id_proveedor
            });
        }
    }
}
