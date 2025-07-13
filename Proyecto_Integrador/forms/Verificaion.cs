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





        }

        private void txtVerificacion_TextChanged(object sender, EventArgs e)
        {
            int longitud = txtVerificacion.Text.Length;
            if (longitud > 18)
            {
                MessageBox.Show("La CURP no puede tener más de 18 caracteres.");

                txtVerificacion.Text = txtVerificacion.Text.Substring(0, 18); // Limita la CURP a 18 caracteres
            }
        }
    }
}
