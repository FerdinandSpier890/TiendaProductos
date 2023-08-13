namespace TiendaProductos.Models.Dto
{
    public class UnidadMedidaDto
    {
        public Guid id_unidad { get; set; }

        public string descripcion { get; set; }

        public DateTime fecha_registro { get; set; }

        public string cve_sat { get; set; }
    }
}
