using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModel
{
    public class ListaProductosViewModel
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string proveedor { get; set; }
        public string marca { get; set; }
        public string medida { get; set; }

        public string descripcion { get; set; }
        public int cantidad { get; set; }

        public decimal precio_unitario { get; set; }

    

    }
}