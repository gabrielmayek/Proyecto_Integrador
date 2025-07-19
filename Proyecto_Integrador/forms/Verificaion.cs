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
            ContenidoPrincipal.Panel.Enabled = false; // Desactiva el panel principal

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
            int estado = clase.EstadoActual(verificacion);
            var DatoP = clase.ObtenerDatosPaciente(verificacion, estado);
            var DatosE = clase.ObtenerEstancias(DatoP != null ? DatoP.id_Paciente : 0);
            var DatosT = clase.ObtenerTratamiento(DatosE != null ? DatosE.Id : 0);
            var DatosGrind = clase.ObtenertratamientoConMedicamentos(DatosT != null ? DatosT.id_tratamiento : 0);

            if (estado == 1)
            {
                MessageBox.Show("Se encontraron datos registrados.");
                ContenidoPrincipal.Actualizar.Enabled = true;   
                ContenidoPrincipal.Nombres.ReadOnly = true;
                ContenidoPrincipal.Curp.ReadOnly = true;
                ContenidoPrincipal.Apellido_paterno.ReadOnly = true;
                ContenidoPrincipal.Apellido_materno.ReadOnly = true;
                ContenidoPrincipal.Medico.DropDownStyle = ComboBoxStyle.Simple;
                ContenidoPrincipal.Medico.Enabled = false;
                ContenidoPrincipal.Causa.DropDownStyle = ComboBoxStyle.Simple;
                ContenidoPrincipal.Causa.Enabled = false;

                ContenidoPrincipal.Nombres.Text = DatoP.Nombres;
                ContenidoPrincipal.Curp.Text = DatoP.Curp;
                ContenidoPrincipal.Apellido_paterno.Text = DatoP.Apellido_Paterno;
                ContenidoPrincipal.Apellido_materno.Text = DatoP.Apellido_Materno;

                if (DatosT.estudio_clinico == 1)
                {
                    ContenidoPrincipal.RadioButton.Checked = true;
                }
                else
                {
                    ContenidoPrincipal.RadioButton.Checked = false;
                }

                foreach (var item in DatosGrind.Where(m => m.UsoActualmente == "SI"))
                {
                    ContenidoPrincipal.Dgvdatos.Rows.Add(item.id_medicamento, item.Medicamento, item.tiempoAdministracion, item.cantidad, item.Efecto_secundario);
                }

                ContenidoPrincipal.Guardar.Hide();
                ContenidoPrincipal.Actualizar.Show();
                ContenidoPrincipal.Panel.Enabled = true;
                this.Close();
            }
            else
            {
                if (DatoP == null)

                {
                    MessageBox.Show("No se encontraron datos registrados.");

                    // Habilitar campos para registrar nuevo paciente
                    ContenidoPrincipal.Panel.Enabled = true;
                    ContenidoPrincipal.Nombres.ReadOnly = false;
                    ContenidoPrincipal.Curp.ReadOnly = false;
                    ContenidoPrincipal.Apellido_paterno.ReadOnly = false;
                    ContenidoPrincipal.Apellido_materno.ReadOnly = false;
                    ContenidoPrincipal.Medico.DropDownStyle = ComboBoxStyle.DropDown;
                    ContenidoPrincipal.Medico.Enabled = true;
                    ContenidoPrincipal.Causa.DropDownStyle = ComboBoxStyle.DropDown;
                    ContenidoPrincipal.Causa.Enabled = true;

                    ContenidoPrincipal.Nombres.Text = "";
                    ContenidoPrincipal.Curp.Text = verificacion; // Puedes dejar la CURP ya escrita
                    ContenidoPrincipal.Apellido_paterno.Text = "";
                    ContenidoPrincipal.Apellido_materno.Text = "";
                    ContenidoPrincipal.Dgvdatos.Rows.Clear();
                    ContenidoPrincipal.RadioButton.Checked = false;

                    ContenidoPrincipal.Guardar.Show();
                    ContenidoPrincipal.Actualizar.Hide();
                    ContenidoPrincipal.Actualizar.Enabled=true;
                    this.Close();
                }
                else if (DatosGrind.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos registrados.");

                    ContenidoPrincipal.Panel.Enabled = true;
                    ContenidoPrincipal.Nombres.Text = "";
                    ContenidoPrincipal.Curp.Text = "";
                    ContenidoPrincipal.Apellido_paterno.Text = "";
                    ContenidoPrincipal.Apellido_materno.Text = "";
                    ContenidoPrincipal.Dgvdatos.Rows.Clear();
                    ContenidoPrincipal.RadioButton.Checked = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Se encontraron datos registrados.");
                    ContenidoPrincipal.Nombres.Text = DatoP.Nombres;
                    ContenidoPrincipal.Curp.Text = DatoP.Curp;
                    ContenidoPrincipal.Apellido_paterno.Text = DatoP.Apellido_Paterno;
                    ContenidoPrincipal.Apellido_materno.Text = DatoP.Apellido_Materno;

                    if (DatosT.estudio_clinico == 1)
                    {
                        ContenidoPrincipal.RadioButton.Checked = true;
                    }
                    else
                    {
                        ContenidoPrincipal.RadioButton.Checked = false;
                    }

                    foreach (var item in DatosGrind)
                    {
                        ContenidoPrincipal.Dgvdatos.Rows.Add(item.id_medicamento, item.Medicamento, item.tiempoAdministracion, item.cantidad, item.Efecto_secundario);
                    }

                    ContenidoPrincipal.Guardar.Hide();
                    ContenidoPrincipal.Actualizar.Show();
                    ContenidoPrincipal.Panel.Enabled = true;
                    this.Close();
                }
            }
        }

        


        // Limita la longitud de la CURP a 18 caracteres
        private void txtVerificacion_TextChanged(object sender, EventArgs e)
      
        {
            int longitud = txtVerificacion.Text.Length;
            if (longitud > 18)
            {
                MessageBox.Show("La CURP no puede tener más de 18 caracteres.");
                txtVerificacion.Text = txtVerificacion.Text.Substring(0, 18); // Limita la CURP a 18 caracteres
            }

        }


        // Permite solo letras y números en la CURP
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
