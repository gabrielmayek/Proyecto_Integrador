using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Medico
    {
        public int? id_medico { get; set; }
        public int? cedula { get; set; }
        public string? nombres { get; set; }
        public string? apellido_materno { get; set; }
        public string? apellido_paterno { get; set; }


        public string Nombre_completo// Propiedad que devuelve el nombre completo del médico
        {
            get {return $"{nombres} {apellido_paterno} {apellido_materno}"; }
  
        }

    }
}
