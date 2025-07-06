namespace Proyecto_Integrador
{
    partial class Verificacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtVerificacion = new TextBox();
            btnVerificar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(96, 27);
            label1.Name = "label1";
            label1.Size = new Size(191, 31);
            label1.TabIndex = 0;
            label1.Text = "registro existente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(108, 71);
            label2.Name = "label2";
            label2.Size = new Size(152, 31);
            label2.TabIndex = 0;
            label2.Text = "Ingresa CURP";
            // 
            // txtVerificacion
            // 
            txtVerificacion.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVerificacion.Location = new Point(37, 105);
            txtVerificacion.Name = "txtVerificacion";
            txtVerificacion.Size = new Size(320, 38);
            txtVerificacion.TabIndex = 1;
            // 
            // btnVerificar
            // 
            btnVerificar.BackColor = Color.FromArgb(177, 232, 134);
            btnVerificar.BackgroundImageLayout = ImageLayout.Center;
            btnVerificar.FlatStyle = FlatStyle.Popup;
            btnVerificar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerificar.Location = new Point(108, 193);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(165, 43);
            btnVerificar.TabIndex = 2;
            btnVerificar.Text = "button1";
            btnVerificar.UseVisualStyleBackColor = false;
            // 
            // Verificacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(129, 166, 100);
            ClientSize = new Size(384, 284);
            Controls.Add(btnVerificar);
            Controls.Add(txtVerificacion);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Verificacion";
            Text = "Verificaion";
            Load += Verificaion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtVerificacion;
        private Button btnVerificar;
    }
}