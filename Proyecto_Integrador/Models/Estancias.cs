using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Estancias
    {
        public int Id { get; set; }
        public string? id_paciente { get; set; }
        public DateTime FechaInicio {  get; set; }
        public DateTime FechaSalisa { get; set; }
    }
}
