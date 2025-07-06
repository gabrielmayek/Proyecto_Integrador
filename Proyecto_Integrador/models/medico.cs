using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.models
{
    public class Medico
    {
        public int id_medico { get; set; }
        public int cedula { get; set; }
        public string? nombres { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }


        public string nombreCompleto
        {
           get 
           { return $"{nombres} {apellido_paterno} {apellido_materno}"; }
        }

    }
}
