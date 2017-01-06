using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DatosContacto
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int DatosPersonalesId { get; set; }
        public virtual DatosPersonales DatosPersonales { get; set; }



    }
}
