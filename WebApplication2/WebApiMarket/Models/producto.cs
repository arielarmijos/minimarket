using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMarket.Models
{
    public class producto
    {
        public int id { get; set; }
        public int id_categoria { get; set; }
        public string categoria { get; set; }
        public int id_proveedor { get; set; }
        public string proveedor { get; set; }
        public int id_marca { get; set; }
        public string marca { get; set; }
        public string medidas { get; set; }

        public string descripcion { get; set; }
        public int cantidad { get; set; }

        public decimal precio_unitario { get; set; }

    }
}