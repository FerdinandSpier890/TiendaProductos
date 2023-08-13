namespace TiendaProductos.Models.Dto
{
    public class ArticulosDto
    {
        public string Cod_Barras { get; set; }
        public string Cod_Asociado { get; set; }
        public long Id_Clasificacion { get; set; }
        public string Cod_Interno { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Corta { get; set; }
        public decimal? Cantidad_Um { get; set; }
        public Guid? Id_Unidad { get; set; }
        public Guid? Id_Proveedor { get; set; }
        public decimal? Precio_Compra { get; set; }
        public decimal? Utilidad { get; set; }
        public decimal? Precio_Venta { get; set; }
        public string Tipo_Articulo { get; set; }
        public decimal? Stock { get; set; }
        public decimal? Stock_Min { get; set; }
        public decimal? Stock_Max { get; set; }
        public decimal? Iva { get; set; }
        public DateTime Kit_Fecha_Ini { get; set; }
        public DateTime Kit_Fecha_Fin { get; set; }
        public bool Articulo_Disponible { get; set; }
        public bool Kit { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public bool Visible { get; set; }
        public short Puntos { get; set; }
        public DateTime Last_Update_Inventory { get; set; }
        public string Cve_Producto { get; set; }
    }
}
