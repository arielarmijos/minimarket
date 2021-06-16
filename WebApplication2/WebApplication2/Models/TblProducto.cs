using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class TblProducto
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
