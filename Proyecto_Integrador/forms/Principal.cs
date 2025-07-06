using Proyecto_Integrador.Data;
using Proyecto_Integrador.models;
using System.Windows.Forms;
namespace Proyecto_Integrador
{
    public partial class Principal : Form
    {
        public Principal()
        {


            InitializeComponent();
            var datos = new Datos(); // Crea una instancia de la clase datos
            datos.CargarCombo(cmbMedicamentos); // Llama al método para probar la conexión a la base de datos
            datos.CargarComboMedicos(cmbMedico); // Llama al método para cargar los médicos en el ComboBox

            cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMedicamentos.Text = "Selecciona un medicamento"; // Establece el texto predeterminado del ComboBox
            cmbMedicamentos.Font = new Font("Verdana", 14);
            dtimeEntrada.Font = new Font("Verdana", 12);


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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            
            
            // Crea una instancia de la clase datos
            var datos = new Datos();

            // Obtiene el ID del medicamento seleccionado
            Medicamento medicamento = (Medicamento)cmbMedicamentos.SelectedItem;
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
            // Inserta los datos del medicamento en la base de datos
            Dictionary<string, Object> datosMedicos = new Dictionary<string, object>
            {
                {"id_paciente",idPaciente },
                {"estudio_clinico",respuesta2 },
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








        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cmbMedicamentos.SelectedItem is Medicamento medicamento &&
              int.TryParse(txtAdministracion.Text, out int administracion) &&
               int.TryParse(txtCantidad.Text, out int cantidad))
            {
                _ = dgvDatos.Rows.Add(medicamento.Id,medicamento.Nombre, administracion, cantidad);

                cmbMedicamentos.SelectedIndex = -1;
                txtAdministracion.Clear();
                txtCantidad.Clear();
            }
            else
            {
                MessageBox.Show("Completa todos los campos correctamente.");
            }
        }
    }
}

