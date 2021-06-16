using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApiMarket.Models;

namespace WebApiMarket.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/values
        [HttpGet]
        public  List<producto> Get()
           
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            producto Response = new producto();
            SqlCommand sqlCommand = null;


            List<producto> lista = new List<producto>();

            try
            {
                sqlConnection.Open();
              

                sqlCommand = new SqlCommand("usp_consulta_Productos", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", 1);

                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);


                foreach (DataRow row in dt.Rows)
                {
                    Response.id = Convert.ToInt16(row["id"]);
                    Response.categoria = row["categoria"].ToString();
                    Response.proveedor = row["proveedor"].ToString();
                    Response.marca = row["marca"].ToString();
                    Response.medidas = row["medidas"].ToString();
                    Response.descripcion = row["descripcion"].ToString();
                    Response.cantidad = Convert.ToInt16(row["cantidad"]);
                    Response.precio_unitario = Convert.ToDecimal(row["precio_unitario"]);
                    lista.Add(Response);
                }


               
            
            }
            catch (Exception ex)
            {

            }
            finally { sqlConnection.Close(); }

            return lista;


        }

        // GET api/values/5
        public List<producto> Get(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            producto Response = new producto();
            SqlCommand sqlCommand = null;


            List<producto> lista = new List<producto>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("usp_consulta_Productos", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", 2);
                sqlCommand.Parameters.AddWithValue("@id", id);


                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);


                foreach (DataRow row in dt.Rows)
                {
                    Response.id = Convert.ToInt16(row["id"]);
                    Response.categoria = row["categoria"].ToString();
                    Response.proveedor = row["proveedor"].ToString();
                    Response.marca = row["marca"].ToString();
                    Response.medidas = row["medidas"].ToString();
                    Response.descripcion = row["descripcion"].ToString();
                    Response.cantidad = Convert.ToInt16(row["cantidad"]);
                    Response.precio_unitario = Convert.ToDecimal(row["precio_unitario"]);
                    lista.Add(Response);
                }

            }
            catch (Exception ex)
            {

            }
            finally { sqlConnection.Close(); }

            return lista;
        }

        // POST api/values
       
        public Response Post([FromBody]producto value)
        {
            Response oResponse = new Response();

            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                Models.producto producto = new producto();
                producto.id_categoria = value.id_categoria;
                producto.id_proveedor = value.id_proveedor;
                producto.id_marca = value.id_marca;
                producto.descripcion = value.descripcion;
                producto.medidas = value.medidas;
                producto.cantidad = value.cantidad;
                producto.precio_unitario = value.precio_unitario;
                db.SaveChanges();

                oResponse.ResponseCode = "00";
                oResponse.ResponseMessage = "Registro ingresado con exito!";
                oResponse.Result = true;

            }


            return oResponse;

        }

        // PUT api/values/5
        public void Put( [FromBody]producto value)
        {
            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                  tbl_producto  producto = db.tbl_producto.Find(value.id);
                    producto.id_categoria = value.id_categoria;
                    producto.id_proveedor = value.id_proveedor;
                    producto.id_marca = value.id_marca;
                    producto.descripcion = value.descripcion;
                    producto.medidas = value.medidas;
                    producto.cantidad = value.cantidad;
                    producto.precio_unitario = value.precio_unitario;
                    db.SaveChanges();


            }



        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (db_minimarketEntities db = new db_minimarketEntities())
            {

                tbl_producto producto = db.tbl_producto.Find(id);
                db.tbl_producto.Remove(producto);
                db.SaveChanges();


            }
        }
    }
}
