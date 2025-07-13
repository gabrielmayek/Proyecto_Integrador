
using Proyecto_Integrador.Data;
using Proyecto_Integrador.Models;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Proyecto_Integrador
{
    public partial class Principal : Form
    {

        
        public System.Windows.Forms.TextBox txtnombres => txtNombres;
        public System.Windows.Forms.TextBox txtcurp => txtCurp;
        public System.Windows.Forms.TextBox txtapellido_paterno => txtApellidoPaterno;
        public System.Windows.Forms.TextBox apellido_materno => txtApellidoMeterno;
       
        public System.Windows.Forms.RadioButton radioButton => rbtnSIEstudiosClinicos;
        public System.Windows.Forms.DataGridView dgvdatos => dgvDatos;
        public System.Windows.Forms.ComboBox datos_del_medico => cmbMedico;


        public Principal()
        {

            InitializeComponent();
            var datos = new Datos(); // Crea una instancia de la clase datos
            datos.CargarComboMedicamentos(cmbMedicamentos); //Llama al método para cargar los medicamentos en el ComboBox
            datos.CargarComboMedicos(cmbMedico); // Llama al método para cargar los médicos en el ComboBox
            datos.CargarComboCausas(cmbCausa);
            cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCausa.AutoCompleteMode= AutoCompleteMode.SuggestAppend;
            cmbCausa.AutoCompleteSource= AutoCompleteSource.ListItems;
            cmbMedicamentos.Text = "Selecciona un medicamento"; // Establece el texto predeterminado del ComboBox
            cmbMedicamentos.Font = new Font("Verdana", 14);
            dtimeEntrada.Font = new Font("Verdana", 12);
            guardarbtn.Enabled = false;
            List<string> tipos = new List<string> { "mL", "L", "µL", "cc", "gota", "cdita", "cda", "mg", "g", "kg", "mcg", "ng", "UI", "U", "mEq", "mol", "mmol", "UFC" };
            cmbTipo.DataSource= tipos;
          
        }














        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                tabControlMenu.Appearance = TabAppearance.FlatButtons;// Establece el estilo de las pestañas la apariencia de las pestañas es plana
                tabControlMenu.ItemSize = new Size(0, 2);// Establece el tamaño de las pestañas muy pequeño para que no se vean
                tabControlMenu.SizeMode = TabSizeMode.Fixed;// Establece el modo de tamaño de las pestañas conbinado los dos anteriores oculta las pestañas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esto es un " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Establece la pestaña de inicio como la pestaña seleccionada al cargar el formulario
            tabControlMenu.SelectedTab = Mensajebienvenida; // Establece la pestaña de inicio como la pestaña seleccionada al cargar el formulario


            dgvDatos.Columns.Clear(); // Limpia columnas previas si las hay
            dgvDatos.Columns.Add("Id_medicamento", "ID");
            dgvDatos.Columns["Id_medicamento"].Visible = false; // Oculta la columna de ID

            dgvDatos.Columns.Add("Nombre", "Medicamento");
            dgvDatos.Columns.Add("Administracion", "Administración (horas)");
            dgvDatos.Columns.Add("Cantidad", "Cantidad");
            dgvDatos.Columns.Add("Efecto_secundario", "Efecto Secundario");
            dgvDatos.Columns["Administracion"].Width = 200; // Ajusta el ancho de la columna de administración
            dgvDatos.Columns["Cantidad"].Width = 246; // Ajusta el ancho de la columna de cantidad
            dgvDatos.Columns["Nombre"].Width = 400; // Ajusta el ancho de la columna de nombre
            dgvDatos.Columns["Efecto_secundario"].Width = 200; // Ajusta el ancho de la columna de efecto secundario
            dtimeEntrada.Value = DateTime.Now; //Actualiza la hora al dia de hoy

        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {

            tabControlMenu.SelectedTab = Registar; // Cambia a la pestaña de registro
            Form Verificar = new Verificacion(this); // Crea una instancia del formulario de verificación
            Verificar.Show();


        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            tabControlMenu.SelectedTab = Activos; // Cambia a la pestaña de activos
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            tabControlMenu.SelectedTab = Historial; // Cambia a la pestaña de historial
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void guardarbtn_Click(object sender, EventArgs e)
        {


            // Crea una instancia de la clase datos
            var datos = new Datos();
            // Obtiene el médico seleccionado del ComboBox
            Medico medico = (Medico)cmbMedico.SelectedItem;
            Causas causa= (Causas)cmbCausa.SelectedItem;

            //Datos personales del paciente
            string nombres = txtNombres.Text;
            string apellidoMaterno = txtApellidoMeterno.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string curp = txtCurp.Text;

            //Datos Medicos del paciente
        

            int respuesta2 = rbtnSIEstudiosClinicos.Checked ? 1 : 0;// verifica que si se seleciono Si
            DateTime fechaEntrada = dtimeEntrada.Value;
            DateTime fechaDefecto = new DateTime(2025, 7, 10, 9, 30, 0); // Año, mes, día, hora, minuto, segundo
            //tratamiento del paciente
            string efectos = txtEfectoSecundario.Text;
            //Medico que atiende al paciente
            Dictionary<string, object> paciente = new Dictionary<string, object>// Crea un diccionario para almacenar los datos personales
            {
                { "curp", curp },
                { "nombres", nombres },
                { "apellido_materno", apellidoMaterno },
                { "apellido_paterno", apellidoPaterno },
                { "estado_actual",1 }
            };
            int idPaciente = datos.Insertar("paciente", paciente);

            Dictionary<string, object> estancia = new Dictionary<string, object>
            {
              {"id_paciente",idPaciente},
              {"fecha_entrada",fechaEntrada},
              {"fecha_salida", fechaDefecto}
            };
          int id_estancia =  datos.Insertar("estancias", estancia);

            // Inserta los datos del medicamentoElegido en la base de datos
            Dictionary<string, Object> tratamiento = new Dictionary<string, object>
            {
                {"id_estancia",id_estancia },
                {"id_medico",medico.id_medico },
                {"id_causa",causa.Id_causas },
                {"estudio_clinico",respuesta2 }
            };
            int id_tratamiento = datos.Insertar("tratamiento", tratamiento);


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (!row.IsNewRow)
                {
                    int idMedicamento = Convert.ToInt32(row.Cells["Id_medicamento"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int tiempoAdministracion = Convert.ToInt32(row.Cells["Administracion"].Value);
                    string efectoSecundario = row.Cells["Efecto_secundario"].Value?.ToString() ?? string.Empty;

                    Dictionary<string, object> datosTratamientoMedicamento = new Dictionary<string, object>

                   {
                        {"id_tratamiento",id_tratamiento },
                        { "id_medicamento", idMedicamento },
                        { "cantidad", cantidad },
                        { "tiempo_administracion", tiempoAdministracion },
                        {"efecto_secundario", efectoSecundario },

                   };

                    datos.Insertar("tratamiento_medicamento", datosTratamientoMedicamento);
                }
            }

            txtNombres.Clear();
            txtAdministracion.Clear();
            txtApellidoMeterno.Clear();
            txtApellidoPaterno.Clear();
            cmbCausa.SelectedIndex = -1;
            txtCurp.Clear();

        }




        private void txtCurp_TextChanged(object sender, EventArgs e)
        {
            int longitud = txtCurp.Text.Length;
            if (longitud > 18)
            {
                MessageBox.Show("La CURP no puede tener más de 18 caracteres.");

                txtCurp.Text = txtCurp.Text.Substring(0,18); // Limita la CURP a 18 caracteres
            }
            ValidarFormulario();

        }

        private void txtCausa_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();

        }







        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbMedicamentos.SelectedItem is Medicamento medicamentoElegido &&
            int.TryParse(txtAdministracion.Text, out int administracion) &&
             int.TryParse(txtCantidad.Text, out int cantidad))
            {
                string secundario = txtEfectoSecundario.Text;

                _ = dgvDatos.Rows.Add(medicamentoElegido.Id, medicamentoElegido.Nombre, administracion, cantidad, secundario);
                //_ sirve para ignorar el valor de retorno del método Rows.Add
                cmbMedicamentos.SelectedIndex = -1;//Regresa a una pocision anterior
                txtAdministracion.Clear();//
                txtCantidad.Clear();
                txtEfectoSecundario.Clear();
            }
            else
            {

                MessageBox.Show("Completa todos los campos correctamente.");

            }
        }

        //SOLO ACEPTE LETRAS

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtApellidoMeterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtApellidoPaterno_KeyPress(Object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtCausa_KeyPress(Object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtEfectoSecundario_KeyPress(Object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }
        //SOLO ACEPTE NUMEROS
        private void txtCantidad_KeyPress(Object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtAdministracion_KeyPress(Object seder, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        //ICONO DE ADVERTENCIA POR NO LLENAR LOS CAMPOS 
        private void txtNombres_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtNombres);

        }
        private void txtCantidad_Validating(object seder, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtCantidad);
        }
        private void txtEfectoSecundario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtEfectoSecundario);
        }

        private void txtAdministracion_Validating(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtAdministracion);
        }

        private void txtApellidoMaterno_Validating(object seneder, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtApellidoMeterno);
        }


        private void txtApellidoPaterno_Validating(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtApellidoPaterno);
        }

        private void txtCurp_Validating(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtCurp);
        }



        //VALIDAR PARA ACTIVAR EL BOTON
        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void txtApellidoPaterno_TextChanged(Object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void txtEfectoSecundario_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }


        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }
        private void cmbCausa_SelectedIndexChanged(Object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void DgvDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ValidarFormulario();
        }

        private void DgvDatos_RowsChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }





        //FUNCIONES PARA REUTILIZAR 
        private void Advertencia(System.ComponentModel.CancelEventArgs e, System.Windows.Forms.TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider1.SetError(txt, "El campo Nombres es obligatorio.");
            }
            else
            {
                errorProvider1.SetError(txt, "");
            }
        }

        private void soloLetras(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Función para validar el formulario y habilitar o deshabilitar el botón de guardar
        private void ValidarFormulario()

        {
            bool textBoxesLlenos = !string.IsNullOrWhiteSpace(txtNombres.Text) &&
            !string.IsNullOrWhiteSpace(txtApellidoMeterno.Text) &&
            !string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) &&
            !string.IsNullOrWhiteSpace(txtCurp.Text);

            bool comboSeleccionados = cmbMedico.SelectedIndex > 0;
            bool comboCausa = cmbCausa.SelectedIndex > 0;
            bool dataGridConDatos = dgvDatos.Rows
            .Cast<DataGridViewRow>()
            .Any(row => !row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null));

            guardarbtn.Enabled = textBoxesLlenos && comboSeleccionados && dataGridConDatos&&comboCausa;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvDatos.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }

        }
    }

}

