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


        public ActionResult Nuevo()
        {

          

            List<TablaViewModelCategoria> lst;
            List<TablaViewModelProveedor> lstprv;
            List<TablaViewModelMarca> lstmarca;

            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                lst = (from d in db.tbl_categoria

                       select new TablaViewModelCategoria
                       {
                           Id = d.id,
                           Categoria = d.categoria

                       }).ToList();

                List<SelectListItem> item = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Categoria,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                 ViewBag.Items = item;

                lstprv = (from d in db.tbl_proveedor

                       select new TablaViewModelProveedor
                       {
                           Id = d.id,
                           Proveedor = d.proveedor

                       }).ToList();

                List<SelectListItem> itemprv = lstprv.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Proveedor,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                ViewBag.Itemsprv = itemprv;


                lstmarca = (from d in db.tbl_marca

                          select new TablaViewModelMarca
                          {
                              Id = d.id,
                              Marca = d.marca

                          }).ToList();

                List<SelectListItem> itemmarca = lstmarca.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Marca,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                ViewBag.Itemsmarca = itemmarca;



            }

            return View();

        }


        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db_minimarketEntities db = new db_minimarketEntities())
                    {

                       
                        var oTabla = new tbl_producto();
                        oTabla.id_categoria = Convert.ToInt16(Request.Form["Categoria"].ToString()); 
                        oTabla.id_proveedor = Convert.ToInt16(Request.Form["Proveedor"].ToString()); 
                        oTabla.id_marca = Convert.ToInt16(Request.Form["Marca"].ToString()); 
                        oTabla.descripcion= model.Descripcion;
                        oTabla.cantidad = model.Cantidad;
                        oTabla.precio_unitario = model.PrecioUnitario;

                        db.tbl_producto.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (db_minimarketEntities db = new db_minimarketEntities())
            {
                var oTabla = db.tbl_producto.Find(Id);
                model.IdCategoria = oTabla.id_categoria;
                model.IdProveedor = oTabla.id_proveedor;
                model.IdMarca = oTabla.id_marca;
                model.Descripcion = oTabla.descripcion;
                model.Cantidad = oTabla.cantidad;
                model.PrecioUnitario = oTabla.precio_unitario;
                model.Id = oTabla.id;
            }

            List<TablaViewModelCategoria> lst;
            List<TablaViewModelProveedor> lstprv;
            List<TablaViewModelMarca> lstmarca;

            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                lst = (from d in db.tbl_categoria

                       select new TablaViewModelCategoria
                       {
                           Id = d.id,
                           Categoria = d.categoria

                       }).ToList();

                List<SelectListItem> item = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Categoria,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                ViewBag.Items = item;

                lstprv = (from d in db.tbl_proveedor

                          select new TablaViewModelProveedor
                          {
                              Id = d.id,
                              Proveedor = d.proveedor

                          }).ToList();

                List<SelectListItem> itemprv = lstprv.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Proveedor,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                ViewBag.Itemsprv = itemprv;


                lstmarca = (from d in db.tbl_marca

                            select new TablaViewModelMarca
                            {
                                Id = d.id,
                                Marca = d.marca

                            }).ToList();

                List<SelectListItem> itemmarca = lstmarca.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Marca,
                        Value = d.Id.ToString(),
                        Selected = false

                    };

                });

                ViewBag.Itemsmarca = itemmarca;



            }

         

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db_minimarketEntities db = new db_minimarketEntities())
                    {
                        var oTabla = db.tbl_producto.Find(model.Id);
                        oTabla.id_categoria = Convert.ToInt16(Request.Form["IdCategoria"].ToString());
                        oTabla.id_proveedor = Convert.ToInt16(Request.Form["IdProveedor"].ToString());
                        oTabla.id_marca = Convert.ToInt16(Request.Form["IdMarca"].ToString());
                        oTabla.descripcion = model.Medidas;
                        oTabla.descripcion = model.Descripcion;
                        oTabla.cantidad = model.Cantidad;
                        oTabla.precio_unitario = model.PrecioUnitario;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Producto/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                var oTabla = db.tbl_producto.Find(Id);
                db.tbl_producto.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Producto/");
        }

    }
}