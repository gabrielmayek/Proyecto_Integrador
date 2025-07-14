using Microsoft.VisualBasic;
using Proyecto_Integrador.Data;
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

        private Principal ContenidoPrincipal;
        public Verificacion(Principal principal)
        {
            InitializeComponent();
            ContenidoPrincipal = principal;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evita que se pueda cambiar el tamaño
            this.MaximizeBox = false; // Desactiva el botón de maximizar
            this.MinimizeBox = false; // Desactiva el botón de minimizar
            ContenidoPrincipal.panel.Enabled = false; // Desactiva el panel principal

        }

        private void Verificaion_Load(object sender, EventArgs e)
        {


            StartPosition = FormStartPosition.Manual;// Establece la posición de inicio del formulario
            Location = new Point(300, 200); // X=300, Y=200


        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string verificacion = txtVerificacion.Text;
            var clase = new Datos();


            var datoP = clase.ObtenerDatosPaciente(verificacion);
            if (datoP == null)
            {
                MessageBox.Show("No se encontró ningún registro con esa CURP.");
                ContenidoPrincipal.panel.Enabled = true; // Reactiva el panel principal
                this.Close();
            }
            else
            {
                var datosE = clase.OBtenerEstancias(datoP.id_Paciente);
                var datosT = clase.ObtenerTratamiento(datosE.Id);
                var datosGrind = clase.ObtenertratamientoConMedicamentos(datosT.id_tratamiento);

                ContenidoPrincipal.txtnombres.Text = datoP.Nombres;
                ContenidoPrincipal.txtcurp.Text = datoP.Curp;
                ContenidoPrincipal.txtapellido_paterno.Text = datoP.Apellido_Paterno;
                ContenidoPrincipal.apellido_materno.Text = datoP.Apellido_Materno;
                if (datosT.estudio_clinico == 1)
                {
                    ContenidoPrincipal.radioButton.Checked = true;
                }
                else
                {
                    ContenidoPrincipal.radioButton.Checked = false;
                }

                foreach (var item in datosGrind)
                {

                    ContenidoPrincipal.dgvdatos.Rows.Add(item.id_medicaemto, item.Medicamento, item.tiempoAdministracion, item.cantidad, item.Efecto_secundario);
                }

                ContenidoPrincipal.guardar.Hide();
                ContenidoPrincipal.Actualiar.Show();
                ContenidoPrincipal.panel.Enabled = true; // Reactiva el panel principal
                this.Close();
            }


        }

        private void txtVerificacion_TextChanged(object sender, EventArgs e)
        {
            int longitud = txtVerificacion.Text.Length;
            if (longitud > 18)
            {
                MessageBox.Show("La CURP no puede estar vacia y debe tener más de 18 caracteres.");
                txtVerificacion.Text = txtVerificacion.Text.Substring(0, 18); // Limita la CURP a 18 caracteres
            }

        }

        private void txtVerificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }



        // Esto desactiva el botón de cerrar (X)
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

    }
}
