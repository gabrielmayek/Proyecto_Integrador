using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Paciente
    {
        public int id_Paciente {  get; set; }
        public string? Curp { get; set; }
        public string? Nombres { get; set; }
        public string? Apellido_Paterno { get; set; }
        public string? Apellido_Materno { get; set; }
        public int estado_actual { get; set; }

    }
}
