using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integrador.Models
{
    internal class Medicamento
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }


        public override string ToString()
        {
            return Nombre?? "";
        }
    }
}
