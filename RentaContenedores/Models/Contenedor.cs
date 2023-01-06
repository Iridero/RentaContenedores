using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaContenedores.Models
{
    public class Contenedor:BaseEntity
    {
        public int Numero { get; set; }
        public string Pasillo { get; set; }
        public string Dimensiones { get; set; }
        public DateOnly UltimoPago { get; set; }
        public decimal Adeudo { get; set; }
        public int? IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
