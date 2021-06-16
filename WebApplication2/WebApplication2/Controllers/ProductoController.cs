using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {

            List<ListaProductosViewModel> lst;

            using (db_minimarketEntities db = new db_minimarketEntities())
            {
                 
                lst = (from d in db.tbl_producto 
                       join cat in db.tbl_categoria on d.id_categoria equals cat.id
                       join prov in db.tbl_proveedor on d.id_proveedor equals prov.id
                       join marca in db.tbl_marca on d.id_marca equals marca.id

                       select new ListaProductosViewModel
                       {
                           id = d.id,
                           categoria = cat.categoria.ToString(),
                           proveedor = prov.proveedor.ToString(),
                           marca = marca.marca.ToString(),
                           descripcion = d.descripcion,
                           medida = d.medidas,
                           cantidad = d.cantidad,
                           precio_unitario = d.precio_unitario

                       }).ToList();

            }


            return View(lst);


        }
    }
}