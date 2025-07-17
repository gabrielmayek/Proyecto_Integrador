using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Tratamiento_medicamento
    {
        public int id_tratamiento {  get; set; }

        public int id_medicamento { get; set; }

        public int cantidad { get; set; }
        public int tiempoAdministracion {  get; set; }  
        public string? UsoActualmente {  get; set; }

        public string? Efecto_secundario { get; set; }

        public Medicamento? Medicamento { get; set; }
    }
}
