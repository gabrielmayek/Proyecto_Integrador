using Pomelo.EntityFrameworkCore.MySql.Metadata.Internal;
using Proyecto_Integrador.Data;
using Proyecto_Integrador.Models;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Proyecto_Integrador
{
    public partial class Principal : Form
    {

        public Principal()
        {

            InitializeComponent();
            var datos = new Datos(); // Crea una instancia de la clase datos
            datos.CargarComboMedicamentos(cmbMedicamentos); //Llama al método para cargar los medicamentos en el ComboBox
            datos.CargarComboMedicos(cmbMedico); // Llama al método para cargar los médicos en el ComboBox

            cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMedicamentos.Text = "Selecciona un medicamento"; // Establece el texto predeterminado del ComboBox
            cmbMedicamentos.Font = new Font("Verdana", 14);
            dtimeEntrada.Font = new Font("Verdana", 12);
            guardarbtn.Enabled = false;

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
            dgvDatos.Columns["Administracion"].Width = 300; // Ajusta el ancho de la columna de administración
            dgvDatos.Columns["Cantidad"].Width = 300; // Ajusta el ancho de la columna de cantidad
            dgvDatos.Columns["Nombre"].Width = 290; // Ajusta el ancho de la columna de nombre



        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {

            tabControlMenu.SelectedTab = Registar; // Cambia a la pestaña de registro
            Form Verificar = new Verificacion(); // Crea una instancia del formulario de verificación
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

            //Datos personales del paciente
            string nombres = txtNombres.Text;
            string apellidoMaterno = txtApellidoMeterno.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string curp = txtCurp.Text;

            //Datos Medicos del paciente
            string causa = txtCausa.Text;

            int respuesta2 = rbtnSIEstudiosClinicos.Checked ? 1 : 0;// verifica que si se seleciono Si
            DateTime fechaEntrada = dtimeEntrada.Value;
            //tratamiento del paciente
            string efectos = txtEfectoSecundario.Text;
            //Medico que atiende al paciente
            Dictionary<string, object> datospersonales = new Dictionary<string, object>// Crea un diccionario para almacenar los datos personales
            {
                { "curp", curp },
                { "nombres", nombres },
                { "apellido_materno", apellidoMaterno },
                { "apellido_paterno", apellidoPaterno }
            };
            int idPaciente = datos.Insertar("datos_personales", datospersonales);
            // Inserta los datos del medicamentoElegido en la base de datos
            Dictionary<string, Object> datosMedicos = new Dictionary<string, object>
            {
                {"id_paciente",idPaciente },
                {"estudio_clinico",respuesta2 },
                {"causa",causa },
                {"fecha_entrada",fechaEntrada },
                {"id_medico",medico.id_medico }
            };
            int Id_datosMedicos = datos.Insertar("datos_medicos", datosMedicos);
            Dictionary<string, object> datosTratamiento = new Dictionary<string, object>
            {
                {"id_datos_medicos",Id_datosMedicos },
                {"efecto_secundario",efectos },

            };
            int idTratamiento = datos.Insertar("tratamiento", datosTratamiento);


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (!row.IsNewRow)
                {
                    int idMedicamento = Convert.ToInt32(row.Cells["Id_medicamento"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int tiempoAdministracion = Convert.ToInt32(row.Cells["Administracion"].Value);

                    Dictionary<string, object> datosTratamientoMedicamento = new Dictionary<string, object>

            {
                 { "id_tratamiento", idTratamiento },
                 { "id_medicamento", idMedicamento },
                 { "cantidad", cantidad },
                 { "tiempo_administracion", tiempoAdministracion }
            };

                    datos.Insertar("tratamiento_medicamento", datosTratamientoMedicamento);
                }
            }




        }

        private void txtCurp_TextChanged(object sender, EventArgs e)
        {
            int longitud = txtCurp.Text.Length;
            if (longitud > 18)
            {
                MessageBox.Show("La CURP no puede tener más de 18 caracteres.");

                txtCurp.Text = txtCurp.Text.Substring(0, 18); // Limita la CURP a 18 caracteres
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
                _ = dgvDatos.Rows.Add(medicamentoElegido.Id, medicamentoElegido.Nombre, administracion, cantidad);
                //_ sirve para ignorar el valor de retorno del método Rows.Add
                cmbMedicamentos.SelectedIndex = -1;//Regresa a una pocision anterior
                txtAdministracion.Clear();//
                txtCantidad.Clear();
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

        private void txtAdministracion_KeyPress(Object seder,KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        //ICONO DE ADVERTENCIA POR NO LLENAR LOS CAMPOS 
        private void txtNombres_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtNombres);

        }
        private void txtCantidad_Validating(object seder,System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtCantidad);
        }
        private void txtEfectoSecundario_Validating(object sender,System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtEfectoSecundario);
        }

        private void txtAdministracion_Validating(Object sender,System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtAdministracion);
        }

        private void txtApellidoMaterno_Validating(object seneder,System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtApellidoMeterno);
        }


        private void txtApellidoPaterno_Validating(Object sender,System.ComponentModel.CancelEventArgs e) 
        {
            Advertencia(e,txtApellidoPaterno);
        }

        private void txtCurp_Validating(Object sender,System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtCurp);
        }

        private void txtCausa_Validating(Object sender , System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e,txtCausa);
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

       private void txtEfectoSecundario_TextChanged(object sender,EventArgs e)
        {
            ValidarFormulario();    
        }


        private void cmbMedico_SelectedIndexChanged(object sender , EventArgs e)
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
                errorProvider1.SetError( txt, "El campo Nombres es obligatorio.");
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


        private void ValidarFormulario()
        {
            bool textBoxesLlenos = !string.IsNullOrWhiteSpace(txtNombres.Text) &&
            !string.IsNullOrWhiteSpace(txtApellidoMeterno.Text) &&
            !string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) &&
            !string.IsNullOrWhiteSpace(txtCurp.Text) &&
            !string.IsNullOrWhiteSpace(txtCausa.Text) &&
            !string.IsNullOrWhiteSpace(txtEfectoSecundario.Text);

            bool comboSeleccionados =  cmbMedico.SelectedIndex > 0;

            bool dataGridConDatos = dgvDatos.Rows
            .Cast<DataGridViewRow>()
            .Any(row => !row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null));

            guardarbtn.Enabled = textBoxesLlenos && comboSeleccionados && dataGridConDatos;
        }




    }

}

