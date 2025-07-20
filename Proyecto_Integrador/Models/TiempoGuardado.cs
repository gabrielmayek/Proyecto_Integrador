using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class TiempoGuardado
    {

  
        public Dictionary<string, TimeSpan> TiemposRestantes { get; set; } 
        public DateTime  FechaGuardado { get; set; }

    }
}
