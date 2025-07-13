
namespace Proyecto_Integrador
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panel1 = new Panel();
            btnHistorial = new Button();
            btnActivos = new Button();
            btnRegistar = new Button();
            Historial = new TabPage();
            label3 = new Label();
            Activos = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Registar = new TabPage();
            panel2 = new Panel();
            label2 = new Label();
            cmbTipo = new ComboBox();
            cmbCausa = new ComboBox();
            btnEliminar = new Button();
            btnAgregar = new Button();
            cmbMedico = new ComboBox();
            guardarbtn = new Button();
            dtimeEntrada = new DateTimePicker();
            dgvDatos = new DataGridView();
            cmbMedicamentos = new ComboBox();
            rbtnNOEstudiosClinicos = new RadioButton();
            rbtnSIEstudiosClinicos = new RadioButton();
            label12 = new Label();
            label6 = new Label();
            label8 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label10 = new Label();
            label7 = new Label();
            txtCantidad = new TextBox();
            txtEfectoSecundario = new TextBox();
            txtAdministracion = new TextBox();
            txtApellidoMeterno = new TextBox();
            txtApellidoPaterno = new TextBox();
            label18 = new Label();
            label13 = new Label();
            label11 = new Label();
            label9 = new Label();
            label5 = new Label();
            txtCurp = new TextBox();
            txtNombres = new TextBox();
            label1 = new Label();
            tabControlMenu = new TabControl();
            Mensajebienvenida = new TabPage();
            label4 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            Historial.SuspendLayout();
            Activos.SuspendLayout();
            Registar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            tabControlMenu.SuspendLayout();
            Mensajebienvenida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnHistorial);
            panel1.Controls.Add(btnActivos);
            panel1.Controls.Add(btnRegistar);
            panel1.Location = new Point(1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(152, 710);
            panel1.TabIndex = 0;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.FromArgb(177, 232, 134);
            btnHistorial.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 128);
            btnHistorial.FlatAppearance.BorderSize = 2;
            btnHistorial.FlatStyle = FlatStyle.Popup;
            btnHistorial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistorial.Location = new Point(7, 246);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(135, 86);
            btnHistorial.TabIndex = 4;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnActivos
            // 
            btnActivos.BackColor = Color.FromArgb(177, 232, 134);
            btnActivos.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 128);
            btnActivos.FlatAppearance.BorderSize = 2;
            btnActivos.FlatStyle = FlatStyle.Popup;
            btnActivos.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActivos.Location = new Point(7, 154);
            btnActivos.Name = "btnActivos";
            btnActivos.Size = new Size(135, 86);
            btnActivos.TabIndex = 3;
            btnActivos.Text = "Pacientes Activos";
            btnActivos.UseVisualStyleBackColor = false;
            btnActivos.Click += btnActivos_Click;
            // 
            // btnRegistar
            // 
            btnRegistar.BackColor = Color.FromArgb(177, 232, 134);
            btnRegistar.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 128);
            btnRegistar.FlatAppearance.BorderSize = 2;
            btnRegistar.FlatStyle = FlatStyle.Popup;
            btnRegistar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistar.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistar.Location = new Point(7, 62);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(135, 86);
            btnRegistar.TabIndex = 0;
            btnRegistar.Text = "Registar";
            btnRegistar.UseVisualStyleBackColor = false;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // Historial
            // 
            Historial.BackColor = Color.FromArgb(129, 166, 100);
            Historial.Controls.Add(label3);
            Historial.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Historial.Location = new Point(4, 29);
            Historial.Name = "Historial";
            Historial.Padding = new Padding(3);
            Historial.Size = new Size(994, 683);
            Historial.TabIndex = 2;
            Historial.Text = "Historial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(377, 51);
            label3.Name = "label3";
            label3.Size = new Size(279, 38);
            label3.TabIndex = 0;
            label3.Text = "Apartado de Historial";
            // 
            // Activos
            // 
            Activos.BackColor = Color.FromArgb(129, 166, 100);
            Activos.Controls.Add(flowLayoutPanel1);
            Activos.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Activos.Location = new Point(4, 29);
            Activos.Name = "Activos";
            Activos.Padding = new Padding(3);
            Activos.Size = new Size(994, 683);
            Activos.TabIndex = 1;
            Activos.Text = "Activos";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 15);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(994, 662);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Registar
            // 
            Registar.BackColor = Color.FromArgb(129, 166, 100);
            Registar.Controls.Add(panel2);
            Registar.Controls.Add(label1);
            Registar.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Registar.Location = new Point(4, 29);
            Registar.Name = "Registar";
            Registar.Padding = new Padding(3);
            Registar.Size = new Size(994, 683);
            Registar.TabIndex = 0;
            Registar.Text = "Registrar";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(129, 166, 100);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cmbTipo);
            panel2.Controls.Add(cmbCausa);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(cmbMedico);
            panel2.Controls.Add(guardarbtn);
            panel2.Controls.Add(dtimeEntrada);
            panel2.Controls.Add(dgvDatos);
            panel2.Controls.Add(cmbMedicamentos);
            panel2.Controls.Add(rbtnNOEstudiosClinicos);
            panel2.Controls.Add(rbtnSIEstudiosClinicos);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtCantidad);
            panel2.Controls.Add(txtEfectoSecundario);
            panel2.Controls.Add(txtAdministracion);
            panel2.Controls.Add(txtApellidoMeterno);
            panel2.Controls.Add(txtApellidoPaterno);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtCurp);
            panel2.Controls.Add(txtNombres);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 683);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(277, 836);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 15;
            label2.Text = "Tipo";
            // 
            // cmbTipo
            // 
            cmbTipo.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(157, 836);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(114, 33);
            cmbTipo.TabIndex = 14;
            // 
            // cmbCausa
            // 
            cmbCausa.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCausa.FormattingEnabled = true;
            cmbCausa.Location = new Point(29, 383);
            cmbCausa.Name = "cmbCausa";
            cmbCausa.Size = new Size(534, 33);
            cmbCausa.TabIndex = 13;
            cmbCausa.SelectedIndexChanged += cmbCausa_SelectedIndexChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(177, 232, 134);
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Location = new Point(472, 1224);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(213, 46);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(177, 232, 134);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(723, 1224);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(218, 46);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cmbMedico
            // 
            cmbMedico.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMedico.FormattingEnabled = true;
            cmbMedico.Location = new Point(32, 1339);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(487, 33);
            cmbMedico.TabIndex = 10;
            cmbMedico.SelectedIndexChanged += cmbMedico_SelectedIndexChanged;
            // 
            // guardarbtn
            // 
            guardarbtn.BackColor = Color.FromArgb(177, 232, 134);
            guardarbtn.FlatStyle = FlatStyle.Flat;
            guardarbtn.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guardarbtn.Location = new Point(723, 1339);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(218, 52);
            guardarbtn.TabIndex = 7;
            guardarbtn.Text = "Guardar";
            guardarbtn.UseVisualStyleBackColor = false;
            guardarbtn.Click += guardarbtn_Click;
            // 
            // dtimeEntrada
            // 
            dtimeEntrada.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtimeEntrada.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtimeEntrada.Location = new Point(633, 383);
            dtimeEntrada.Name = "dtimeEntrada";
            dtimeEntrada.Size = new Size(270, 32);
            dtimeEntrada.TabIndex = 8;
            dtimeEntrada.Value = new DateTime(2025, 7, 5, 0, 0, 0, 0);
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(41, 895);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(900, 300);
            dgvDatos.TabIndex = 6;
            dgvDatos.CellValueChanged += DgvDatos_CellValueChanged;
            dgvDatos.RowsAdded += DgvDatos_RowsChanged;
            dgvDatos.RowsRemoved += DgvDatos_RowsChanged;
            // 
            // cmbMedicamentos
            // 
            cmbMedicamentos.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMedicamentos.FormattingEnabled = true;
            cmbMedicamentos.Location = new Point(41, 696);
            cmbMedicamentos.Name = "cmbMedicamentos";
            cmbMedicamentos.Size = new Size(565, 33);
            cmbMedicamentos.TabIndex = 4;
            // 
            // rbtnNOEstudiosClinicos
            // 
            rbtnNOEstudiosClinicos.AutoSize = true;
            rbtnNOEstudiosClinicos.ForeColor = Color.Transparent;
            rbtnNOEstudiosClinicos.Location = new Point(30, 545);
            rbtnNOEstudiosClinicos.Name = "rbtnNOEstudiosClinicos";
            rbtnNOEstudiosClinicos.Size = new Size(75, 42);
            rbtnNOEstudiosClinicos.TabIndex = 3;
            rbtnNOEstudiosClinicos.TabStop = true;
            rbtnNOEstudiosClinicos.Text = "No";
            rbtnNOEstudiosClinicos.UseVisualStyleBackColor = true;
            // 
            // rbtnSIEstudiosClinicos
            // 
            rbtnSIEstudiosClinicos.AutoSize = true;
            rbtnSIEstudiosClinicos.ForeColor = Color.White;
            rbtnSIEstudiosClinicos.Location = new Point(30, 497);
            rbtnSIEstudiosClinicos.Name = "rbtnSIEstudiosClinicos";
            rbtnSIEstudiosClinicos.Size = new Size(60, 42);
            rbtnSIEstudiosClinicos.TabIndex = 3;
            rbtnSIEstudiosClinicos.TabStop = true;
            rbtnSIEstudiosClinicos.Text = "Si";
            rbtnSIEstudiosClinicos.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(41, 1312);
            label12.Name = "label12";
            label12.Size = new Size(91, 28);
            label12.TabIndex = 1;
            label12.Text = "Medico";
            label12.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(34, 30);
            label6.Name = "label6";
            label6.Size = new Size(211, 28);
            label6.TabIndex = 1;
            label6.Text = "Datos Personales";
            label6.Click += label5_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(360, 73);
            label8.Name = "label8";
            label8.Size = new Size(205, 28);
            label8.TabIndex = 1;
            label8.Text = "Apellido Materno";
            label8.Click += label5_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(41, 785);
            label17.Name = "label17";
            label17.Size = new Size(314, 28);
            label17.TabIndex = 1;
            label17.Text = "Cantidad de medicamento";
            label17.Click += label5_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(422, 785);
            label16.Name = "label16";
            label16.Size = new Size(222, 28);
            label16.TabIndex = 1;
            label16.Text = "Efecto Secundario";
            label16.Click += label5_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(648, 649);
            label15.Name = "label15";
            label15.Size = new Size(293, 28);
            label15.TabIndex = 1;
            label15.Text = "Administracion en horas";
            label15.Click += label5_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(633, 334);
            label10.Name = "label10";
            label10.Size = new Size(214, 28);
            label10.TabIndex = 1;
            label10.Text = "Fecha de Entrada";
            label10.Click += label5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(640, 73);
            label7.Name = "label7";
            label7.Size = new Size(199, 28);
            label7.TabIndex = 1;
            label7.Text = "Apellido Paterno";
            label7.Click += label5_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(41, 837);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 32);
            txtCantidad.TabIndex = 0;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            txtCantidad.Validating += txtCantidad_Validating;
            // 
            // txtEfectoSecundario
            // 
            txtEfectoSecundario.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEfectoSecundario.Location = new Point(422, 837);
            txtEfectoSecundario.Name = "txtEfectoSecundario";
            txtEfectoSecundario.Size = new Size(250, 32);
            txtEfectoSecundario.TabIndex = 0;
            txtEfectoSecundario.TextChanged += txtEfectoSecundario_TextChanged;
            txtEfectoSecundario.KeyPress += txtEfectoSecundario_KeyPress;
            txtEfectoSecundario.Validating += txtEfectoSecundario_Validating;
            // 
            // txtAdministracion
            // 
            txtAdministracion.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdministracion.Location = new Point(648, 697);
            txtAdministracion.Name = "txtAdministracion";
            txtAdministracion.Size = new Size(100, 32);
            txtAdministracion.TabIndex = 0;
            txtAdministracion.KeyPress += txtAdministracion_KeyPress;
            txtAdministracion.Validating += txtAdministracion_Validating;
            // 
            // txtApellidoMeterno
            // 
            txtApellidoMeterno.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidoMeterno.Location = new Point(360, 111);
            txtApellidoMeterno.Name = "txtApellidoMeterno";
            txtApellidoMeterno.Size = new Size(200, 32);
            txtApellidoMeterno.TabIndex = 0;
            txtApellidoMeterno.TextChanged += txtApellidoMaterno_TextChanged;
            txtApellidoMeterno.KeyPress += txtApellidoMeterno_KeyPress;
            txtApellidoMeterno.Validating += txtApellidoMaterno_Validating;
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidoPaterno.Location = new Point(640, 111);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(200, 32);
            txtApellidoPaterno.TabIndex = 0;
            txtApellidoPaterno.TextChanged += txtApellidoPaterno_TextChanged;
            txtApellidoPaterno.KeyPress += txtApellidoPaterno_KeyPress;
            txtApellidoPaterno.Validating += txtApellidoPaterno_Validating;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.White;
            label18.Location = new Point(26, 163);
            label18.Name = "label18";
            label18.Size = new Size(67, 28);
            label18.TabIndex = 1;
            label18.Text = "Curp";
            label18.Click += label5_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(26, 334);
            label13.Name = "label13";
            label13.Size = new Size(83, 28);
            label13.TabIndex = 1;
            label13.Text = "Causa";
            label13.Click += label5_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(29, 466);
            label11.Name = "label11";
            label11.Size = new Size(204, 28);
            label11.TabIndex = 1;
            label11.Text = "Estudios Clinicos";
            label11.Click += label5_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(41, 649);
            label9.Name = "label9";
            label9.Size = new Size(165, 28);
            label9.TabIndex = 1;
            label9.Text = "Medicamento";
            label9.Click += label5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(34, 74);
            label5.Name = "label5";
            label5.Size = new Size(115, 28);
            label5.TabIndex = 1;
            label5.Text = "Nombres";
            label5.Click += label5_Click;
            // 
            // txtCurp
            // 
            txtCurp.CharacterCasing = CharacterCasing.Upper;
            txtCurp.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurp.Location = new Point(29, 213);
            txtCurp.Name = "txtCurp";
            txtCurp.Size = new Size(270, 32);
            txtCurp.TabIndex = 0;
            txtCurp.TextChanged += txtCurp_TextChanged;
            txtCurp.Validating += txtCurp_Validating;
            // 
            // txtNombres
            // 
            txtNombres.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(30, 111);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(250, 32);
            txtNombres.TabIndex = 0;
            txtNombres.TextChanged += txtNombres_TextChanged;
            txtNombres.KeyPress += txtNombres_KeyPress;
            txtNombres.Validating += txtNombres_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 28);
            label1.Name = "label1";
            label1.Size = new Size(0, 38);
            label1.TabIndex = 0;
            // 
            // tabControlMenu
            // 
            tabControlMenu.Anchor = AnchorStyles.Top;
            tabControlMenu.Controls.Add(Registar);
            tabControlMenu.Controls.Add(Activos);
            tabControlMenu.Controls.Add(Historial);
            tabControlMenu.Controls.Add(Mensajebienvenida);
            tabControlMenu.Location = new Point(159, -3);
            tabControlMenu.Name = "tabControlMenu";
            tabControlMenu.SelectedIndex = 0;
            tabControlMenu.Size = new Size(1002, 716);
            tabControlMenu.TabIndex = 1;
            tabControlMenu.SelectedIndexChanged += tabControlMenu_SelectedIndexChanged;
            // 
            // Mensajebienvenida
            // 
            Mensajebienvenida.BackColor = Color.FromArgb(129, 166, 100);
            Mensajebienvenida.Controls.Add(label4);
            Mensajebienvenida.Location = new Point(4, 29);
            Mensajebienvenida.Name = "Mensajebienvenida";
            Mensajebienvenida.Padding = new Padding(3);
            Mensajebienvenida.Size = new Size(994, 683);
            Mensajebienvenida.TabIndex = 3;
            Mensajebienvenida.Text = "bienvenida";
            Mensajebienvenida.Click += tabPage1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Unicode MS", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(152, 197);
            label4.Name = "label4";
            label4.Size = new Size(664, 161);
            label4.TabIndex = 3;
            label4.Text = "Bienvenido";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 705);
            Controls.Add(tabControlMenu);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Principal";
            Padding = new Padding(50, 50, 20, 30);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control del cuidado del paciente";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            Historial.ResumeLayout(false);
            Historial.PerformLayout();
            Activos.ResumeLayout(false);
            Registar.ResumeLayout(false);
            Registar.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            tabControlMenu.ResumeLayout(false);
            Mensajebienvenida.ResumeLayout(false);
            Mensajebienvenida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }


        private void tabControlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private Panel panel1;
        private Button btnRegistar;
        private Button btnHistorial;
        private Button btnActivos;
        private TabPage Historial;
        private Label label3;
        private TabPage Activos;
        private TabPage Registar;
        private Label label1;
        private TabControl tabControlMenu;
        private TabPage Mensajebienvenida;
        private Label label4;
        private Panel panel2;
        private TextBox txtNombres;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private TextBox txtApellidoMeterno;
        private TextBox txtApellidoPaterno;
        private Label label12;
        private Label label10;
        private Label label13;
        private Label label9;
        private TextBox txtCurp;
        private RadioButton rbtnNOEstudiosClinicos;
        private RadioButton rbtnSIEstudiosClinicos;
        private Label label11;
        private ComboBox cmbMedicamentos;
        private Label label15;
        private TextBox txtAdministracion;
        private Label label17;
        private Label label16;
        private TextBox txtCantidad;
        private TextBox txtEfectoSecundario;
        private DataGridView dgvDatos;
        private Label label18;
        private Button guardarbtn;
        private DateTimePicker dtimeEntrada;
        private ComboBox cmbMedico;
        private Button btnAgregar;
        private ErrorProvider errorProvider1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnEliminar;
        private ComboBox cmbCausa;
        private Label label2;
        private ComboBox cmbTipo;
    }
}
