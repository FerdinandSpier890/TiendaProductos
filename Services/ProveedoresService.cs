using TiendaProductos.Models.Dto;
using TiendaProductos.Services.IServices;

namespace TiendaProductos.Services
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IBaseService _baseService;
        public ProveedoresService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> GetAllSupplersAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = Utility.SD.ProveedoresApiBase + "/api/Proveedores"
            });
        }

        public async Task<ResponseDto> CreateVendedorAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = null,
                Url = Utility.SD.ProveedoresApiBase + "/api/proveedor"
            });
        }

        public async Task<ResponseDto> UpdateVendedorAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.PUT,
                Data = null,
                Url = Utility.SD.ProveedoresApiBase + "/api/proveedor"
            });
        }
    }
}
