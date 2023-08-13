using Microsoft.AspNetCore.Mvc;
using static TiendaProductos.Utility.SD;

namespace TiendaProductos.Models.Dto
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public object Data { get; set; }

        public string AccessToken { get; set; }
    }
}
