using TiendaProductos.Models.Dto;
using TiendaProductos.Services.IServices;

namespace TiendaProductos.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IBaseService _baseService;

        public PedidosService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto> GetAllPedidos()
        {
            throw new NotImplementedException();
        }
    }
}
