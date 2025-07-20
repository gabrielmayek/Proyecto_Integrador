namespace Proyecto_Integrador
{
    partial class PacienteActivoControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblNombres = new Label();
            lblApellidoPaterno = new Label();
            lblApellidoMaterno = new Label();
            lblDiasInternados = new Label();
            btnDarDeAlta = new Button();
            lblTituloTiempoFaltante = new Label();
            flpVariable = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Font = new Font("Microsoft Sans Serif", 10F);
            lblNombres.Location = new Point(17, 20);
            lblNombres.Margin = new Padding(5, 0, 5, 0);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(82, 20);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres:";
            // 
            // lblApellidoPaterno
            // 
            lblApellidoPaterno.AutoSize = true;
            lblApellidoPaterno.Font = new Font("Segoe UI", 10F);
            lblApellidoPaterno.Location = new Point(17, 53);
            lblApellidoPaterno.Margin = new Padding(5, 0, 5, 0);
            lblApellidoPaterno.Name = "lblApellidoPaterno";
            lblApellidoPaterno.Size = new Size(140, 23);
            lblApellidoPaterno.TabIndex = 1;
            lblApellidoPaterno.Text = "Apellido Paterno:";
            // 
            // lblApellidoMaterno
            // 
            lblApellidoMaterno.AutoSize = true;
            lblApellidoMaterno.Font = new Font("Segoe UI", 10F);
            lblApellidoMaterno.Location = new Point(17, 88);
            lblApellidoMaterno.Margin = new Padding(5, 0, 5, 0);
            lblApellidoMaterno.Name = "lblApellidoMaterno";
            lblApellidoMaterno.Size = new Size(146, 23);
            lblApellidoMaterno.TabIndex = 2;
            lblApellidoMaterno.Text = "Apellido Materno:";
            // 
            // lblDiasInternados
            // 
            lblDiasInternados.AutoSize = true;
            lblDiasInternados.Font = new Font("Segoe UI", 10F);
            lblDiasInternados.Location = new Point(17, 308);
            lblDiasInternados.Margin = new Padding(5, 0, 5, 0);
            lblDiasInternados.Name = "lblDiasInternados";
            lblDiasInternados.Size = new Size(133, 23);
            lblDiasInternados.TabIndex = 9;
            lblDiasInternados.Text = "Días Internados:";
            // 
            // btnDarDeAlta
            // 
            btnDarDeAlta.BackColor = Color.Honeydew;
            btnDarDeAlta.Font = new Font("Segoe UI", 9F);
            btnDarDeAlta.Location = new Point(22, 384);
            btnDarDeAlta.Margin = new Padding(5, 4, 5, 4);
            btnDarDeAlta.Name = "btnDarDeAlta";
            btnDarDeAlta.Size = new Size(101, 36);
            btnDarDeAlta.TabIndex = 11;
            btnDarDeAlta.Text = "Dar de alta";
            btnDarDeAlta.UseVisualStyleBackColor = false;
            btnDarDeAlta.Click += btnDarDeAlta_Click;
            // 
            // lblTituloTiempoFaltante
            // 
            lblTituloTiempoFaltante.AutoSize = true;
            lblTituloTiempoFaltante.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloTiempoFaltante.Location = new Point(134, 136);
            lblTituloTiempoFaltante.Margin = new Padding(5, 0, 5, 0);
            lblTituloTiempoFaltante.Name = "lblTituloTiempoFaltante";
            lblTituloTiempoFaltante.Size = new Size(121, 17);
            lblTituloTiempoFaltante.TabIndex = 12;
            lblTituloTiempoFaltante.Text = "Tiempo faltante";
            // 
            // flpVariable
            // 
            flpVariable.AutoScroll = true;
            flpVariable.AutoSize = true;
            flpVariable.Location = new Point(17, 171);
            flpVariable.Name = "flpVariable";
            flpVariable.Size = new Size(250, 125);
            flpVariable.TabIndex = 13;
            // 
            // PacienteActivoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(202, 232, 179);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(flpVariable);
            Controls.Add(btnDarDeAlta);
            Controls.Add(lblDiasInternados);
            Controls.Add(lblApellidoMaterno);
            Controls.Add(lblApellidoPaterno);
            Controls.Add(lblNombres);
            Controls.Add(lblTituloTiempoFaltante);
            Margin = new Padding(5, 4, 5, 4);
            Name = "PacienteActivoControl";
            Size = new Size(294, 447);
            Load += PacienteActivoControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidoPaterno;
        private System.Windows.Forms.Label lblApellidoMaterno;
        private System.Windows.Forms.Label lblDiasInternados;
        private System.Windows.Forms.Button btnDarDeAlta;
        private System.Windows.Forms.Label lblTituloTiempoFaltante;
        private FlowLayoutPanel flpVariable;
    }
}