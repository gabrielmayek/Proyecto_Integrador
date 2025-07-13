using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Tratamiento
    {
        public int id_tratamiento { get; set; } 
        public int estancia{ get; set; }
        public int id_medico { get; set; }
        public int id_causa { get; set; }
        public int estudio_clinico { get; set; }

    }
}
