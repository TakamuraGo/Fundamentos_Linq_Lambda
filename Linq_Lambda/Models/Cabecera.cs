using System;
using System.Collections.Generic;

namespace Linq_Lambda.Models
{
    public class Cabecera
    {
        public int IdCabecera { get; set; }
        public string NroDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Total { get; set; }

        public List<Cabecera_Detalle> Detalles { get; set; }
    }
}
