using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModel
{
    public class TablaViewModel
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdMarca { get; set; }
        public string Medidas { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}