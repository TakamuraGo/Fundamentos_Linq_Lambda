using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLinq.Models;
using ApiLinq.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly PRUEBA_EFContext context;

        public VentaController(PRUEBA_EFContext _context)
        {
            context = _context;
        }
        [HttpGet]
        //Metodo para seleccionar ciertos campos con LINQ
        public IActionResult mostrarVenta()
        {
            var query = from x in context.Venta
                         select new 
                         {
                             x.Idcliente,
                             x.Idusuario,
                             x.NumComprobante,
                             x.SerieComprobante
                         };
            return Ok(query);
        }

        [HttpGet("Traer")]
        public IActionResult MostrarVentaConVM()
        {
            //var query = (from x in context.Venta
            //             select new VentaViewModel
            //             {
            //                 //el primer campo es de VentaViewModel
            //                 //x.idcliente es del repository
            //                 Idventa = x.Idventa,
            //                 Idcliente = x.Idcliente,
            //                 Idusuario = x.Idusuario,
            //                 TipoComprobante = x.TipoComprobante,
            //                 NumComprobante = x.NumComprobante,
            //                 SerieComprobante = x.SerieComprobante,
            //             }).ToList();

            var query = context.Venta.Select(x => new VentaViewModel
            {
                Idventa = x.Idventa,
                Idcliente = x.Idcliente,
                Idusuario = x.Idusuario,
                TipoComprobante = x.TipoComprobante,
                NumComprobante = x.NumComprobante,
                SerieComprobante = x.SerieComprobante,
            }).ToList();
            return Ok(query);
        }

        [HttpGet("UnirCampos")]
        public IActionResult UnirCampos()
        {
            //Unimos las clases: Basta que tenga un FK para que se puedan unir
            var query = from x in context.Venta
                        select new VentaViewModel
                        {
                            Idcliente = x.Idcliente,
                            Idventa = x.Idventa,
                            NumComprobante = x.NumComprobante,
                            IdusuarioNavigation = new UsuarioViewModel
                            {
                                Nombre = x.IdusuarioNavigation.Nombre
                            }
                        };
            return Ok(query);
        }
    }
}
