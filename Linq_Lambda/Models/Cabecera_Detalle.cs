namespace Linq_Lambda.Models
{
    public class Cabecera_Detalle
    {
        public int IdCabecera_Detalle { get; set; }
        public int IdCabecera { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
