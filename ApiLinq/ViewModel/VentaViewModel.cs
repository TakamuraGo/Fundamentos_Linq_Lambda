using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinq.ViewModel
{
    public class VentaViewModel
    {
        public int Idventa { get; set; }
        public int Idcliente { get; set; }
        public int Idusuario { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumComprobante { get; set; }


        //public virtual Persona IdclienteNavigation { get; set; }
        public virtual UsuarioViewModel IdusuarioNavigation { get; set; }
        public virtual ICollection<DetalleVentaViewModel> DetalleVenta { get; set; }
    }
}
