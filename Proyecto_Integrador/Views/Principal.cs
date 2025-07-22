
using Proyecto_Integrador.Data;
using Proyecto_Integrador.Models;
using System;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
namespace Proyecto_Integrador
{
    public partial class Principal : Form
    {
        List<int> idsEliminados = new List<int>();
        public System.Windows.Forms.TextBox Nombres => txtNombres;
        public System.Windows.Forms.TextBox Curp => txtCurp;
        public System.Windows.Forms.TextBox Apellido_paterno => txtApellidoPaterno;
        public System.Windows.Forms.TextBox Apellido_materno => txtApellidoMeterno;
        public System.Windows.Forms.RadioButton RadioButton => rbtnSIEstudiosClinicos;
        public System.Windows.Forms.DataGridView Dgvdatos => dgvDatos;
        public System.Windows.Forms.ComboBox Medico => cmbMedico;
        public System.Windows.Forms.ComboBox Causa => cmbCausa;
        public System.Windows.Forms.Button Guardar => guardarbtn;
        public System.Windows.Forms.Button Actualizar => btnActualizar;
        public System.Windows.Forms.Panel Panel => panelRegistrar;


        private PacienteActivoControl pacienteControl;

        private FlowLayoutPanel flowLayoutPanelHistorial;  //Kevin

        private Panel panelHistorialDetalle; //Kevin

        public Principal()
        {

            InitializeComponent();// Inicializa los componentes del formulario
            InitializeActivosPanel(); // Inicializa el panel de pacientes activos
            CargarPacientesActivos(); // Carga los pacientes activos al iniciar el formulario
            var datos = new Datos(); // Crea una instancia de la clase datos
            datos.CargarComboMedicamentos(cmbMedicamentos); //Llama al método para cargar los medicamentos en el ComboBox
            datos.CargarComboMedicos(cmbMedico); // Llama al método para cargar los médicos en el ComboBox
            datos.CargarComboCausas(cmbCausa);
            cmbMedicamentos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedicamentos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCausa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCausa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMedicamentos.Text = "Selecciona un medicamento"; // Establece el texto predeterminado del ComboBox
            cmbMedicamentos.Font = new Font("Verdana", 12);
            dtimeEntrada.Font = new Font("Verdana", 12);
            guardarbtn.Enabled = false; // Deshabilita el botón de guardar al inicio
            btnActualizar.Enabled = false;
            List<string> tipos = new List<string> { "mL", "L", "µL", "cc", "gota", "cdita", "cda", "mg", "g", "kg", "mcg", "ng", "UI", "U", "mEq", "mol", "mmol", "UFC" };
            cmbTipo.DataSource = tipos;// Carga los tipos de unidades en el ComboBox
            cmbCausa.DropDownStyle = ComboBoxStyle.DropDownList; // Establece el estilo del ComboBox para que no se pueda editar
            pacienteControl = new PacienteActivoControl();// Crea una instancia del control de paciente activo
            pacienteControl.Dock = DockStyle.Fill;// Asegura que el control ocupe todo el espacio disponible en su contenedor
            InitializeHistorialPanel();
        }
        private void InitializeHistorialPanel() //Kevin
        {
            flowLayoutPanelHistorial = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                AutoScroll = true,
                Width = 250,
                BackColor = Color.FromArgb(177, 232, 134), //Kevin: color similar a botones
                Padding = new Padding(10)
            };
            panelHistorialDetalle = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(129, 166, 100), //Kevin: color fondo historial
                Padding = new Padding(20)
            };
            Historial.Controls.Add(panelHistorialDetalle); //Kevin
            Historial.Controls.Add(flowLayoutPanelHistorial); //Kevin
        }






        // Panel para mostrar los pacientes activos
        private FlowLayoutPanel flowLayoutPanelActivos;

        // Método para inicializar el panel de pacientes activos
        private void InitializeActivosPanel()
        {
            flowLayoutPanelActivos = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Visible = true, // Siempre visible dentro de la pesta�a
                Padding = new Padding(10)
            };
            Activos.Controls.Add(flowLayoutPanelActivos); // <-- Cambia aqu�
        }






        // Método para cargar los pacientes activos en el panel
        private void CargarPacientesActivos()
        {
            foreach (Control ctrl in flowLayoutPanelActivos.Controls)
            {
                if (ctrl is PacienteActivoControl pacCtrl)
                {
                    pacCtrl.GuardarEstado();
                }
            }

            flowLayoutPanelActivos.Controls.Clear();

            var datos = new Datos();
            var pacientes = datos.ObtenerPacientesActivos();

            foreach (var paciente in pacientes)
            {
                try
                {
                    var estancia = datos.ObtenerEstancias(paciente.id_Paciente);
                    if (estancia == null) continue;

                    var fechaEntrada = datos.ObtenerFechaEntrada(estancia.Id);
                    if (fechaEntrada == DateTime.MinValue) continue;

                    int diasInternado = (DateTime.Now - fechaEntrada).Days;

                    var tratamiento = datos.ObtenerTratamiento(estancia.Id);
                    if (tratamiento == null) continue;

                    var medicamentos = datos.ObtenertratamientoConMedicamentos(tratamiento.id_tratamiento);

                    var medsDict = medicamentos
                        .Where(m => m.UsoActualmente == "SI")
                        .ToDictionary(
                            m => m.Medicamento?.Nombre ?? "Medicamento",
                            m => TimeSpan.FromHours(m.tiempoAdministracion)
                        );

                    var pacienteControl = new PacienteActivoControl();
                    pacienteControl.SetPacienteInfo(
                        paciente.id_Paciente,
                        paciente.Nombres,
                        paciente.Apellido_Paterno,
                        paciente.Apellido_Materno,
                        diasInternado,
                        medsDict
                    );

                    flowLayoutPanelActivos.Controls.Add(pacienteControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar paciente {paciente.id_Paciente}: {ex.Message}");
                }
            }
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
            dgvDatos.Columns.Add("Unidad","Unidad");
            dgvDatos.Columns.Add("Efecto_secundario", "Efecto Secundario");
            dgvDatos.Columns["Administracion"].Width = 200; // Ajusta el ancho de la columna de administración
            dgvDatos.Columns["Cantidad"].Width = 150; // Ajusta el ancho de la columna de cantidad
            dgvDatos.Columns["Nombre"].Width = 400; // Ajusta el ancho de la columna de nombre
            dgvDatos.Columns["Efecto_secundario"].Width = 200; // Ajusta el ancho de la columna de efecto secundario
            dgvDatos.Columns["Unidad"].Width = 100; // Ajusta el ancho de la columna de unidad
            dtimeEntrada.Value = DateTime.Now; //Actualiza la hora al dia de hoy
            CargarHistorialPacientes();

        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            tabControlMenu.SelectedTab = Registar; // Cambia a la pestaña de registro
            Form Verificar = new Verificacion(this); // Crea una instancia del formulario de verificación
            Verificar.Show();

        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            limpiar();
            flowLayoutPanelActivos.Visible = true;// Muestra el panel de pacientes activos
            tabControlMenu.SelectedTab = Activos; // Cambia a la pestaña de pacientes activos
            CargarPacientesActivos();// Carga los pacientes activos en el panel
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            limpiar();
            tabControlMenu.SelectedTab = Historial; // Cambia a la pestaña de historial
            panelHistorialDetalle.Controls.Clear();
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void guardarbtn_Click(object sender, EventArgs e)
        {
            ValidarFormulario();
            // Crea una instancia de la clase datos
            var datos = new Datos();
            // Obtiene el médico seleccionado del ComboBox
            Medico medico = (Medico)cmbMedico.SelectedItem;
            Causas causa = (Causas)cmbCausa.SelectedItem;
            //Datos personales del paciente
            string nombres = txtNombres.Text;
            string apellidoMaterno = txtApellidoMeterno.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string curp = txtCurp.Text;
            //Datos Medicos del paciente
            int respuesta2 = rbtnSIEstudiosClinicos.Checked ? 1 : 0;// verifica que si se seleciono Si
            DateTime fechaEntrada = dtimeEntrada.Value;
            DateTime fechaDefecto = new DateTime(2000, 1, 1, 0, 0, 0);
            // Año, mes, día, hora, minuto, segundo
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
            // Inserta los datos del paciente en la base de datos y obtiene el ID del paciente

            Dictionary<string, object> estancia = new Dictionary<string, object>
            {
              {"id_paciente",idPaciente},
              {"fecha_entrada",fechaEntrada},
              {"fecha_salida", fechaDefecto}
            };
            int id_estancia = datos.Insertar("estancias", estancia);

            // Inserta los datos del medicamentoElegido en la base de datos
            Dictionary<string, object> tratamiento = new Dictionary<string, object>
            {
                {"id_estancia",id_estancia },
                {"id_medico",medico.id_medico },
                {"id_causa",causa.Id_causas },
                {"estudio_clinico",respuesta2 }
            };
            int id_tratamiento = datos.Insertar("tratamiento", tratamiento);
            // Inserta los datos del tratamiento en la base de datos y obtiene el ID del tratamiento


            //--------------------------------------------------------------------------------------//
            // Recorre las filas del DataGridView y obtiene los datos de cada medicamento

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (!row.IsNewRow)
                {
                    int idMedicamento = Convert.ToInt32(row.Cells["Id_medicamento"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int tiempoAdministracion = Convert.ToInt32(row.Cells["Administracion"].Value);
                    string unidad = row.Cells["Unidad"].Value?.ToString() ?? string.Empty;
                    string efectoSecundario = row.Cells["Efecto_secundario"].Value?.ToString() ?? string.Empty;
                

                    Dictionary<string, object> datosTratamientoMedicamento = new Dictionary<string, object>

                   {
                        {"id_tratamiento",id_tratamiento },
                        { "id_medicamento", idMedicamento },
                        {"Uso_Actualmente","SI" },
                        { "cantidad", cantidad },
                         {"unidad",unidad },
                        { "tiempo_administracion", tiempoAdministracion },
                        {"efecto_secundario", efectoSecundario },

                   };

                    datos.Insertar("tratamiento_medicamento", datosTratamientoMedicamento);
                }
            }
            limpiar();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ValidarFormulario();

            // Obtiene el médico seleccionado del ComboBox
            Medico medico = (Medico)cmbMedico.SelectedItem;
            Causas causa = (Causas)cmbCausa.SelectedItem;
            //Datos Medicos del paciente
            int Respuesta = rbtnSIEstudiosClinicos.Checked ? 1 : 0;// verifica que si se seleciono Si
            DateTime FechaEntrada = dtimeEntrada.Value;
            DateTime FechaDefecto = new DateTime(2000, 1, 1, 0, 0, 0); // Año, mes, día, hora, minuto, segundo
            //tratamiento del paciente
            string Efectos = txtEfectoSecundario.Text;
            var dato = new Datos();
            string Curp = txtCurp.Text;
            string Nombres = txtNombres.Text;
            string ApellidoMaterno = txtApellidoMeterno.Text;
            string ApellidoPaterno = txtApellidoPaterno.Text;
            int EstadoA = dato.EstadoActual(Curp);

            if (EstadoA == 0)
            {
                MessageBox.Show("Estado Actual es 0");
                int id_inactivo = dato.id_inactivo(Curp);
                string curp_inactivo = dato.curp_inactivo(id_inactivo);
                if (Curp == curp_inactivo)
                {
                    // Crea un diccionario para almacenar los datos personales
                    Dictionary<string, object> paciente = new Dictionary<string, object>
                    {
                        { "curp", Curp },
                        { "nombres", Nombres },
                        { "apellido_materno", ApellidoMaterno },
                        { "apellido_paterno", ApellidoPaterno },
                        { "estado_actual",1 }
                    };
                    dato.ActualizarTablas("paciente", paciente, "id_paciente", id_inactivo);
                    Dictionary<string, object> estancia = new Dictionary<string, object>
                    {
                       {"id_paciente",id_inactivo},
                       {"fecha_entrada",FechaEntrada},
                       {"fecha_salida", FechaDefecto}
                    };
                    int id_estancia = dato.Insertar("estancias", estancia);

                    // Inserta los datos del medicamentoElegido en la base de datos
                    Dictionary<string, object> tratamiento = new Dictionary<string, object>
                    {
                      {"id_estancia",id_estancia },
                      {"id_medico",medico.id_medico },
                      {"id_causa",causa.Id_causas },
                      {"estudio_clinico",Respuesta }
                    };
                    int id_tratamiento = dato.Insertar("tratamiento", tratamiento);


                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int idMedicamento = Convert.ToInt32(row.Cells["Id_medicamento"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            int tiempoAdministracion = Convert.ToInt32(row.Cells["Administracion"].Value);
                            string unidad = row.Cells["Unidad"].Value?.ToString() ?? string.Empty;
                            string efectoSecundario = row.Cells["Efecto_secundario"].Value?.ToString() ?? string.Empty;
                          
                            Dictionary<string, object> datosTratamientoMedicamento = new Dictionary<string, object>

                   {
                            {"id_tratamiento",id_tratamiento },
                            { "id_medicamento", idMedicamento },
                            {"Uso_Actualmente","SI" },
                            { "cantidad", cantidad },
                            {"unidad",unidad },
                            { "tiempo_administracion", tiempoAdministracion },
                            {"efecto_secundario", efectoSecundario },
                   };

                            dato.Insertar("tratamiento_medicamento", datosTratamientoMedicamento);
                        }
                    }
                }


                


            }
            else
            {
                MessageBox.Show("Estado Actual es 1");

                var paciente = dato.ObtenerDatosPaciente(Curp, EstadoA);
                int idPaciente = paciente.id_Paciente;
                var estancia = dato.ObtenerEstancias(idPaciente);
                var tratamiento = dato.ObtenerTratamiento(estancia.Id);
                var UsoActualmente = dato.ObtenertratamientoConMedicamentos(tratamiento.id_tratamiento);
                var idsEnUso = UsoActualmente.Where(m => m.UsoActualmente == "SI").Select(m => m.id_medicamento).ToHashSet();
                var IdExiste = UsoActualmente.Where(m => m.UsoActualmente == "NO").Select(m => m.id_medicamento).ToHashSet();

                if (dato.EstanciaActiva(idPaciente))
                {

                    foreach (int idMedicamentoEliminado in idsEliminados)
                    {
                        var datosTratamientoMedicamento2 = new Dictionary<string, object>
                        {
                          { "Uso_Actualmente", "NO" }
                        };
                        dato.ActualizarTablas("tratamiento_medicamento", datosTratamientoMedicamento2, "id_medicamento", idMedicamentoEliminado);
                    }

                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (!row.IsNewRow)  
                        {
                            int idMedicamento = Convert.ToInt32(row.Cells["Id_medicamento"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            int tiempoAdministracion = Convert.ToInt32(row.Cells["Administracion"].Value);
                            string unidad = row.Cells["Unidad"].Value?.ToString() ?? string.Empty;
                            string efectoSecundario = row.Cells["Efecto_secundario"].Value?.ToString() ?? string.Empty;
                   
                            bool estaEnUso = idsEnUso.Contains(idMedicamento);

                            bool existeInactivo = UsoActualmente.Any(m => m.id_medicamento == idMedicamento && m.UsoActualmente == "NO");

                            if (existeInactivo)
                            {
                                MessageBox.Show("Reactivo medicamento inactivo");
                                // Reactivar medicamento previamente inactivo
                                var condiciones = new Dictionary<string, object>
                                {
                                    {"id_tratamiento", tratamiento.id_tratamiento},
                                    {"id_medicamento", idMedicamento},
                                    {"Uso_Actualmente", "NO"}
                                };

                                var ActivarMedicamento = new Dictionary<string, object>
                                {
                                    {"Uso_Actualmente", "SI"},
                                    {"cantidad", cantidad},
                                    {"tiempo_administracion", tiempoAdministracion},
                                    {"efecto_secundario", efectoSecundario}
                                };

                                dato.ActualizarTablasConMasCondiciones("tratamiento_medicamento", ActivarMedicamento, condiciones);
                            }
                            else if (!estaEnUso)
                            {
                                MessageBox.Show("Agregar nuevos medicaementos");
                                // Insertar nuevo medicamento
                                var datosTratamientoMedicamento = new Dictionary<string, object>
                                {
                                    { "id_tratamiento", tratamiento.id_tratamiento },
                                    { "id_medicamento", idMedicamento },
                                    { "cantidad", cantidad },
                                    { "Uso_Actualmente", "SI" },
                                    {"unidad",unidad },
                                    { "tiempo_administracion", tiempoAdministracion },
                                    { "efecto_secundario", efectoSecundario }
                                };

                                dato.Insertar("tratamiento_medicamento", datosTratamientoMedicamento);
                            }

                        }
                    }


                }



            }


            limpiar();




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



        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        // Evento para añadir los datos necesarios al DataGridView
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbMedicamentos.SelectedItem is Medicamento medicamentoElegido &&
            int.TryParse(txtAdministracion.Text, out int administracion) &&
             int.TryParse(txtCantidad.Text, out int cantidad))
            {
                string secundario = txtEfectoSecundario.Text;
                string unidad = cmbTipo.SelectedItem?.ToString() ?? "Otra Unidad"; // Obtiene la unidad seleccionada o usa "mL" por defecto
                _ = dgvDatos.Rows.Add(medicamentoElegido.Id_medicamento, medicamentoElegido.Nombre, administracion, cantidad,unidad, secundario);
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
        // Evento para eliminar los datos seleccionados del DataGridView
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["Id_medicamento"].Value);// Obtiene el ID eliminado del medicamento de la fila seleccionada
                        idsEliminados.Add(id); // Agrega el ID a la lista de IDs eliminados
                        dgvDatos.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }

        }


        private void AgregarBotonHistorial(int idPaciente, string nombres, string apellidoPaterno, string apellidoMaterno, string curp, Medico medico, Causas causa, DateTime fechaEntrada,DateTime fechaSalida)
        {
            string nombreCompleto = $"{nombres} {apellidoPaterno} {apellidoMaterno}";
            System.Windows.Forms.Button btnHistorialPaciente = new System.Windows.Forms.Button //Kevin: especificar Button
            {
                Text = nombreCompleto,
                Width = 200,
                Height = 50,
                BackColor = Color.FromArgb(202, 232, 179), //Kevin: color similar a controles
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Tag = new PacienteHistorialData
                {
                    Id = idPaciente,
                    Nombres = nombres,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    Curp = curp,
                    Medico = medico,
                    Causa = causa,
                    FechaEntrada = fechaEntrada,
                    FechaSalida = fechaSalida 

                }
            };
            btnHistorialPaciente.Click += BtnHistorialPaciente_Click; //Kevin
            flowLayoutPanelHistorial.Controls.Add(btnHistorialPaciente); //Kevin
        }

        //Kevin: Clase auxiliar para datos de historial
        private class PacienteHistorialData
        {
            public int Id;
            public string Nombres;
            public string ApellidoPaterno;
            public string ApellidoMaterno;
            public string Curp;
            public Medico Medico;
            public Causas Causa;
            public DateTime FechaEntrada;
            public DateTime FechaSalida;
        }

        //Kevin: Evento para mostrar plantilla con datos
        private void BtnHistorialPaciente_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn && btn.Tag is PacienteHistorialData data)
            {
                panelHistorialDetalle.Controls.Clear();

                // Obtener causa y medicamentos
                string causa = data.Causa?.causa ?? "";
                string medicamentosTexto = "";
                string medicamentosNOTexto = "";
                var datos = new Datos();
                var estancia = datos.ObtenerEstancias(data.Id);
                if (estancia != null)
                {
                    var tratamiento = datos.ObtenerTratamiento(estancia.Id);
                    if (tratamiento != null)
                    {
                        var medicamentos = datos.ObtenertratamientoConMedicamentos(tratamiento.id_tratamiento)
                            .Where(m => m.UsoActualmente == "SI")
                            .Select(m => m.Medicamento?.Nombre)
                            .Where(n => !string.IsNullOrEmpty(n))
                            .ToList();

                        var medicamentosNO = datos.ObtenertratamientoConMedicamentos(tratamiento.id_tratamiento)
                       .Where(m => m.UsoActualmente == "NO")
                       .Select(m => m.Medicamento?.Nombre)
                       .ToList();

                        if (medicamentos.Count > 0)
                        {
                            medicamentosTexto = string.Join(", ", medicamentos);
                        }
                        if(medicamentosNO.Count>0)
                        {
                         medicamentosNOTexto = string.Join(", ", medicamentosNO);
                        }
                    }
                }
                string descripcion = $"Causa de ingreso: {causa}\r\nMedicamentos administrados: {medicamentosTexto}\r\n Medicamentos retirados: {medicamentosNOTexto}";

                // Panel central para el contenido
                Panel panelCentral = new Panel
                {
                    BackColor = Color.FromArgb(151, 176, 128),
                    Size = new Size(panelHistorialDetalle.Width - 80, panelHistorialDetalle.Height - 80),
                    Location = new Point(40, 40),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
                };

                // Título Paciente
                Label lblPaciente = new Label
                {
                    Text = $"Informacion del paciente: ",
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Location = new Point(30, 20),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblPaciente);

                // Nombres
                Label lblNombres = new Label
                {
                    Text = "Nombres:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(30, 60),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblNombres);
                System.Windows.Forms.TextBox txtNombres = new System.Windows.Forms.TextBox
                {
                    Text = data.Nombres,
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(150, 58),
                    Width = 350,
                    BorderStyle = BorderStyle.None,
                    BackColor = panelCentral.BackColor,
                    ForeColor = Color.White,
                    ReadOnly = true
                };
                panelCentral.Controls.Add(txtNombres);
            

                // Apellidos
                Label lblApellidos = new Label
                {
                    Text = "Apellidos:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(30, 100),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblApellidos);
                System.Windows.Forms.TextBox txtApellidos = new System.Windows.Forms.TextBox
                {
                    Text = $"{data.ApellidoPaterno} {data.ApellidoMaterno}",
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(150, 98),
                    Width = 350,
                    BorderStyle = BorderStyle.None,
                    BackColor = panelCentral.BackColor,
                    ForeColor = Color.White,
                    ReadOnly = true
                };
                panelCentral.Controls.Add(txtApellidos);
          

                // CURP
                Label lblCurp = new Label
                {
                    Text = "Curp:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(30, 140),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblCurp);
                System.Windows.Forms.TextBox txtCurp = new System.Windows.Forms.TextBox
                {
                    Text = data.Curp,
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(150, 138),
                    Width = 350,
                    BorderStyle = BorderStyle.None,
                    BackColor = panelCentral.BackColor,
                    ForeColor = Color.White,
                    ReadOnly = true
                };
                panelCentral.Controls.Add(txtCurp);
         

                // Fechas
                Label lblFechaEntrada = new Label
                {
                    Text = "Fecha de entrada:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(30, 200),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblFechaEntrada);
                Label lblFechaEntradaValor = new Label
                {
                    Text = data.FechaEntrada.ToString("dd/MM/yyyy"),
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(200, 200),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblFechaEntradaValor);
                Label lblFechaSalida = new Label
                {
                    Text = "Fecha de salida:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(350, 200),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblFechaSalida);
                Label lblFechaSalidaValor = new Label
                {
                    Text = data.FechaSalida.ToString("dd/MM/yyyy"), // Puedes reemplazarlo por la fecha real si la tienes
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(500, 200),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblFechaSalidaValor);

                // Descripción
                System.Windows.Forms.TextBox txtDescripcion = new System.Windows.Forms.TextBox
                {
                    Text = descripcion,
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(60, 250),
                    Size = new Size(500, 100),
                    Multiline = true,
                    ReadOnly = true,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                panelCentral.Controls.Add(txtDescripcion);

                // Doctor
                Label lblDoctor = new Label
                {
                    Text = "Doctor:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(60, 380),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblDoctor);
                Label lblDoctorValor = new Label
                {
                    Text = data.Medico?.Nombre_completo ?? "",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(130, 380),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblDoctorValor);

                // Numero de cedula (dejar vacío si no existe la propiedad)
                Label lblCedula = new Label
                {
                    Text = "Numero de cedula:",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(60,400),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblCedula);
                Label lblCedulaValor = new Label
                {

                    Text = data.Medico.cedula.ToString(),
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(250, 400),
                    AutoSize = true
                };
                panelCentral.Controls.Add(lblCedulaValor);

                panelHistorialDetalle.Controls.Add(panelCentral);
            }
        }

        private void CargarHistorialPacientes()
        {
            flowLayoutPanelHistorial.Controls.Clear();
            var datos = new Datos();
            var pacientes = datos.ObtenerTodosPacientes(); 
            foreach (var paciente in pacientes)
            {
                var medico = datos.ObtenerMedicoPorPaciente(paciente.id_Paciente); // Kevin: Implementar si no existe
                var causa = datos.ObtenerCausaPorPaciente(paciente.id_Paciente); // Kevin: Implementar si no existe
                var estancia = datos.ObtenerEstancias(paciente.id_Paciente);
                if (estancia == null) continue;
                DateTime fechaEntrada = datos.ObtenerFechaEntrada(estancia.Id);
                DateTime fechaSalida = datos.ObtenerFechaSalida(estancia.Id);

                AgregarBotonHistorial(paciente.id_Paciente, paciente.Nombres, paciente.Apellido_Paterno, paciente.Apellido_Materno, paciente.Curp, medico, causa, fechaEntrada,fechaSalida);
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

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtCausa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtEfectoSecundario_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }
        //SOLO ACEPTE NUMEROS
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtAdministracion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAdministracion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtAdministracion);
        }

        private void txtApellidoMaterno_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtApellidoMeterno);
        }


        private void txtApellidoPaterno_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Advertencia(e, txtApellidoPaterno);
        }

        private void txtCurp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        private void txtEfectoSecundario_TextChanged(object sender, EventArgs e)
        {

        }


        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarFormulario();
        }
        private void cmbCausa_SelectedIndexChanged(object sender, EventArgs e)
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

        private void limpiar()
        {
            txtNombres.Clear();
            txtAdministracion.Clear();
            txtApellidoMeterno.Clear();
            txtApellidoPaterno.Clear();
            txtCurp.Clear();
            cmbMedicamentos.SelectedIndex = -1;//Regresa a una pocision anterior
            cmbCausa.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            txtAdministracion.Clear();//
            txtCantidad.Clear();
            txtEfectoSecundario.Clear();
            dgvDatos.Rows.Clear(); // Limpia el DataGridView después de actualizar
            btnActualizar.Visible = false; // Deshabilita el botón de actualizar después de guardar
            guardarbtn.Visible = true;
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




        private void ValidarFormulario()
        {
            Datos dato = new Datos();
            string curp = txtCurp.Text;
            int activo = dato.EstadoActual(curp);

            if (activo == 1)
            {
                ValidarFormularioPacienteActivo();
            }
            else if (activo == 0)
            {
                ValidarFormularioPacienteInactivo();
            }
            else
            {
                ValidarFormularioPacienNuevos();
            }
        }


        private void ValidarFormularioPacienteActivo()
        {


            // Solo permitir si hay exactamente una fila válida
            int filasValidas = dgvDatos.Rows.Cast<DataGridViewRow>()
                .Count(row => !row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null));

            if (filasValidas > 0)
            {
                btnActualizar.Text = "Actualizar";
                btnActualizar.Enabled = true;
            }
            else
            {
                btnActualizar.Enabled = false;
            }
        }


        // Función para validar el formulario de pacientes inactivos
        private void ValidarFormularioPacienteInactivo()
        {
            btnActualizar.Text = "Guardar";
            bool textBoxesLlenos = !string.IsNullOrWhiteSpace(txtNombres.Text) &&
                                   !string.IsNullOrWhiteSpace(txtApellidoMeterno.Text) &&
                                   !string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCurp.Text);

            bool comboSeleccionados = cmbMedico.SelectedIndex > 0;
            bool comboCausa = cmbCausa.SelectedIndex > 0;

            bool dataGridConDatos = dgvDatos.Rows.Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null));

            if (textBoxesLlenos && comboSeleccionados && comboCausa && dataGridConDatos)
            {
               
                btnActualizar.Enabled = true;
            }
            else
            {
                btnActualizar.Enabled = false;
            }
        }
        // Función para validar el formulario de pacientes nuevos
        private void ValidarFormularioPacienNuevos()
        {
            bool textBoxesLlenos = !string.IsNullOrWhiteSpace(txtNombres.Text) &&
                                   !string.IsNullOrWhiteSpace(txtApellidoMeterno.Text) &&
                                   !string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCurp.Text);

            bool comboSeleccionados = cmbMedico.SelectedIndex > 0;
            bool comboCausa = cmbCausa.SelectedIndex > 0;

            bool dataGridConDatos = dgvDatos.Rows.Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null));

            if (textBoxesLlenos && comboSeleccionados && comboCausa && dataGridConDatos)
            {

                guardarbtn.Enabled = true;
            }
            else
            {
                guardarbtn.Enabled = false;
            }
        }





        // Función para permitir solo letras y números en el campo CURP
        private void txtCurp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {

            foreach (Control ctrl in flowLayoutPanelActivos.Controls)
            {
                if (ctrl is PacienteActivoControl pacCtrl)
                {
                    pacCtrl.GuardarEstado();
                }
            }

        }
    }

}

