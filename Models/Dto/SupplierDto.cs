using System.Globalization;

namespace TiendaProductos.Models.Dto
{
    public class SupplierDto
    {
        public Nullable<Guid> Id_Proveedor { get; set; }
        public string RFC { get; set; }
        public string Razon_Social { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Tel_Principal { get; set; }
        public string Tel_Movil { get; set; }
        public string E_mail { get; set; }
        public string Estatus { get; set; }
        public Nullable<DateTime> Fecha_Registro { get; set; }
    }
}
