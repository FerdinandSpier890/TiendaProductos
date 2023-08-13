using System.Net;

namespace TiendaProductos.Models.Dto
{
    public class ResponseWrapper
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
