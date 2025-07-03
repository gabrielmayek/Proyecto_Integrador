using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Integrador
{
    public partial class Verificacion : Form
    {
        public Verificacion()
        {
            InitializeComponent();
        }

        private void Verificaion_Load(object sender, EventArgs e)
        {

          
           StartPosition = FormStartPosition.Manual;// Establece la posición de inicio del formulario
           Location = new Point(300, 200); // X=300, Y=200
         
            
        }
    }
}
