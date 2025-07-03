
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panel1 = new Panel();
            btnHistorial = new Button();
            btnActivos = new Button();
            btnRegistar = new Button();
            Historial = new TabPage();
            label3 = new Label();
            Activos = new TabPage();
            label2 = new Label();
            Registar = new TabPage();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            btnguardar = new Button();
            textBox5 = new TextBox();
            cmbMedicamentos = new ComboBox();
            rbtnNOExpediente = new RadioButton();
            rbtnNOEstudiosClinicos = new RadioButton();
            rbtnSiExpediente = new RadioButton();
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
            txtAlergias = new TextBox();
            txtAdministracion = new TextBox();
            txtApellidoMeterno = new TextBox();
            txtFecha = new TextBox();
            txtApellidoPaterno = new TextBox();
            label14 = new Label();
            label18 = new Label();
            label13 = new Label();
            label11 = new Label();
            label9 = new Label();
            label5 = new Label();
            txtCurp = new TextBox();
            txtCausa = new TextBox();
            txtNombres = new TextBox();
            label1 = new Label();
            tabControlMenu = new TabControl();
            Mensajebienvenida = new TabPage();
            label4 = new Label();
            guardarbtn = new Button();
            panel1.SuspendLayout();
            Historial.SuspendLayout();
            Activos.SuspendLayout();
            Registar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControlMenu.SuspendLayout();
            Mensajebienvenida.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnHistorial);
            panel1.Controls.Add(btnActivos);
            panel1.Controls.Add(btnRegistar);
            panel1.Location = new Point(1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(152, 883);
            panel1.TabIndex = 0;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.FromArgb(177, 232, 134);
            btnHistorial.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 128);
            btnHistorial.FlatAppearance.BorderSize = 2;
            btnHistorial.FlatStyle = FlatStyle.Popup;
            btnHistorial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistorial.Location = new Point(7, 226);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(135, 66);
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
            btnActivos.Size = new Size(135, 66);
            btnActivos.TabIndex = 3;
            btnActivos.Text = "Activos";
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
            btnRegistar.Location = new Point(7, 82);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(135, 66);
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
            Historial.Size = new Size(994, 797);
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
            Activos.Controls.Add(label2);
            Activos.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Activos.Location = new Point(4, 29);
            Activos.Name = "Activos";
            Activos.Padding = new Padding(3);
            Activos.Size = new Size(994, 797);
            Activos.TabIndex = 1;
            Activos.Text = "Activos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 136);
            label2.Name = "label2";
            label2.Size = new Size(265, 38);
            label2.TabIndex = 0;
            label2.Text = "Apartado de Activos";
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
            Registar.Size = new Size(994, 797);
            Registar.TabIndex = 0;
            Registar.Text = "Registrar";
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(129, 166, 100);
            panel2.Controls.Add(guardarbtn);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(btnguardar);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(cmbMedicamentos);
            panel2.Controls.Add(rbtnNOExpediente);
            panel2.Controls.Add(rbtnNOEstudiosClinicos);
            panel2.Controls.Add(rbtnSiExpediente);
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
            panel2.Controls.Add(txtAlergias);
            panel2.Controls.Add(txtAdministracion);
            panel2.Controls.Add(txtApellidoMeterno);
            panel2.Controls.Add(txtFecha);
            panel2.Controls.Add(txtApellidoPaterno);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtCurp);
            panel2.Controls.Add(txtCausa);
            panel2.Controls.Add(txtNombres);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 785);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(41, 895);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(857, 188);
            dataGridView1.TabIndex = 6;
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.FromArgb(177, 232, 134);
            btnguardar.FlatAppearance.BorderColor = Color.FromArgb(128, 255, 128);
            btnguardar.FlatAppearance.BorderSize = 2;
            btnguardar.FlatStyle = FlatStyle.Popup;
            btnguardar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnguardar.Location = new Point(741, 1476);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(214, 43);
            btnguardar.TabIndex = 3;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnActivos_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(241, 1529);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(30, 289);
            textBox5.TabIndex = 5;
            // 
            // cmbMedicamentos
            // 
            cmbMedicamentos.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMedicamentos.FormattingEnabled = true;
            cmbMedicamentos.Location = new Point(41, 714);
            cmbMedicamentos.Name = "cmbMedicamentos";
            cmbMedicamentos.Size = new Size(260, 36);
            cmbMedicamentos.TabIndex = 4;
            cmbMedicamentos.SelectedIndexChanged += cmbMedicamentos_SelectedIndexChanged;
            // 
            // rbtnNOExpediente
            // 
            rbtnNOExpediente.AutoSize = true;
            rbtnNOExpediente.ForeColor = Color.Transparent;
            rbtnNOExpediente.Location = new Point(41, 536);
            rbtnNOExpediente.Name = "rbtnNOExpediente";
            rbtnNOExpediente.Size = new Size(75, 42);
            rbtnNOExpediente.TabIndex = 3;
            rbtnNOExpediente.TabStop = true;
            rbtnNOExpediente.Text = "No";
            rbtnNOExpediente.UseVisualStyleBackColor = true;
            // 
            // rbtnNOEstudiosClinicos
            // 
            rbtnNOEstudiosClinicos.AutoSize = true;
            rbtnNOEstudiosClinicos.ForeColor = Color.Transparent;
            rbtnNOEstudiosClinicos.Location = new Point(342, 429);
            rbtnNOEstudiosClinicos.Name = "rbtnNOEstudiosClinicos";
            rbtnNOEstudiosClinicos.Size = new Size(75, 42);
            rbtnNOEstudiosClinicos.TabIndex = 3;
            rbtnNOEstudiosClinicos.TabStop = true;
            rbtnNOEstudiosClinicos.Text = "No";
            rbtnNOEstudiosClinicos.UseVisualStyleBackColor = true;
            // 
            // rbtnSiExpediente
            // 
            rbtnSiExpediente.AutoSize = true;
            rbtnSiExpediente.ForeColor = Color.White;
            rbtnSiExpediente.Location = new Point(41, 488);
            rbtnSiExpediente.Name = "rbtnSiExpediente";
            rbtnSiExpediente.Size = new Size(60, 42);
            rbtnSiExpediente.TabIndex = 3;
            rbtnSiExpediente.TabStop = true;
            rbtnSiExpediente.Text = "Si";
            rbtnSiExpediente.UseVisualStyleBackColor = true;
            // 
            // rbtnSIEstudiosClinicos
            // 
            rbtnSIEstudiosClinicos.AutoSize = true;
            rbtnSIEstudiosClinicos.ForeColor = Color.White;
            rbtnSIEstudiosClinicos.Location = new Point(342, 383);
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
            label12.Location = new Point(41, 1189);
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
            label8.Location = new Point(309, 74);
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
            label16.Location = new Point(725, 674);
            label16.Name = "label16";
            label16.Size = new Size(104, 28);
            label16.TabIndex = 1;
            label16.Text = "Alergias";
            label16.Click += label5_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(349, 683);
            label15.Name = "label15";
            label15.Size = new Size(296, 28);
            label15.TabIndex = 1;
            label15.Text = "Administracion En Horas";
            label15.Click += label5_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(640, 349);
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
            label7.Location = new Point(677, 74);
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
            txtCantidad.Size = new Size(176, 32);
            txtCantidad.TabIndex = 0;
            // 
            // txtAlergias
            // 
            txtAlergias.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAlergias.Location = new Point(725, 714);
            txtAlergias.Name = "txtAlergias";
            txtAlergias.Size = new Size(178, 32);
            txtAlergias.TabIndex = 0;
            // 
            // txtAdministracion
            // 
            txtAdministracion.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdministracion.Location = new Point(346, 714);
            txtAdministracion.Name = "txtAdministracion";
            txtAdministracion.Size = new Size(299, 32);
            txtAdministracion.TabIndex = 0;
            // 
            // txtApellidoMeterno
            // 
            txtApellidoMeterno.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidoMeterno.Location = new Point(304, 111);
            txtApellidoMeterno.Name = "txtApellidoMeterno";
            txtApellidoMeterno.Size = new Size(290, 32);
            txtApellidoMeterno.TabIndex = 0;
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFecha.Location = new Point(640, 391);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(297, 32);
            txtFecha.TabIndex = 0;
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidoPaterno.Location = new Point(640, 111);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(307, 32);
            txtApellidoPaterno.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(26, 436);
            label14.Name = "label14";
            label14.Size = new Size(156, 28);
            label14.TabIndex = 1;
            label14.Text = "Expendiente";
            label14.Click += label5_Click;
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
            label13.Location = new Point(26, 349);
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
            label11.Location = new Point(330, 352);
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
            label9.Location = new Point(41, 665);
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
            txtCurp.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurp.Location = new Point(29, 213);
            txtCurp.Name = "txtCurp";
            txtCurp.Size = new Size(236, 32);
            txtCurp.TabIndex = 0;
            // 
            // txtCausa
            // 
            txtCausa.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCausa.Location = new Point(26, 383);
            txtCausa.Name = "txtCausa";
            txtCausa.Size = new Size(236, 32);
            txtCausa.TabIndex = 0;
            // 
            // txtNombres
            // 
            txtNombres.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(29, 111);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(236, 32);
            txtNombres.TabIndex = 0;
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
            tabControlMenu.Controls.Add(Registar);
            tabControlMenu.Controls.Add(Activos);
            tabControlMenu.Controls.Add(Historial);
            tabControlMenu.Controls.Add(Mensajebienvenida);
            tabControlMenu.Location = new Point(159, -3);
            tabControlMenu.Name = "tabControlMenu";
            tabControlMenu.SelectedIndex = 0;
            tabControlMenu.Size = new Size(1002, 830);
            tabControlMenu.TabIndex = 1;
            // 
            // Mensajebienvenida
            // 
            Mensajebienvenida.BackColor = Color.FromArgb(129, 166, 100);
            Mensajebienvenida.Controls.Add(label4);
            Mensajebienvenida.Location = new Point(4, 29);
            Mensajebienvenida.Name = "Mensajebienvenida";
            Mensajebienvenida.Padding = new Padding(3);
            Mensajebienvenida.Size = new Size(994, 797);
            Mensajebienvenida.TabIndex = 3;
            Mensajebienvenida.Text = "bienvenida";
            Mensajebienvenida.Click += tabPage1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Unicode MS", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(152, 197);
            label4.Name = "label4";
            label4.Size = new Size(664, 161);
            label4.TabIndex = 3;
            label4.Text = "Bienvenido";
            // 
            // guardarbtn
            // 
            guardarbtn.Location = new Point(703, 1203);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(167, 52);
            guardarbtn.TabIndex = 7;
            guardarbtn.Text = "button1";
            guardarbtn.UseVisualStyleBackColor = true;
            guardarbtn.Click += guardarbtn_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 657);
            Controls.Add(tabControlMenu);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Principal";
            Padding = new Padding(50, 50, 20, 30);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Control del cuidado del paciente";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            Historial.ResumeLayout(false);
            Historial.PerformLayout();
            Activos.ResumeLayout(false);
            Activos.PerformLayout();
            Registar.ResumeLayout(false);
            Registar.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControlMenu.ResumeLayout(false);
            Mensajebienvenida.ResumeLayout(false);
            Mensajebienvenida.PerformLayout();
            ResumeLayout(false);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Button btnRegistar;
        private Button btnHistorial;
        private Button btnActivos;
        private TabPage Historial;
        private Label label3;
        private TabPage Activos;
        private Label label2;
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
        private TextBox txtFecha;
        private Label label13;
        private Label label9;
        private TextBox txtCurp;
        private TextBox txtCausa;
        private RadioButton rbtnNOEstudiosClinicos;
        private RadioButton rbtnSIEstudiosClinicos;
        private Label label11;
        private RadioButton rbtnNOExpediente;
        private RadioButton rbtnSiExpediente;
        private Label label14;
        private ComboBox cmbMedicamentos;
        private TextBox textBox5;
        private Label label15;
        private TextBox txtAdministracion;
        private Label label17;
        private Label label16;
        private TextBox txtCantidad;
        private TextBox txtAlergias;
        private DataGridView dataGridView1;
        private Label label18;
        private Button btnguardar;
        private Button guardarbtn;
    }
}
