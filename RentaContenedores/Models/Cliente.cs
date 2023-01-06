using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaContenedores.Models
{
    public  class Cliente:BaseEntity
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public ICollection<Contenedor> Contenedores { get; set; }
    }
}
