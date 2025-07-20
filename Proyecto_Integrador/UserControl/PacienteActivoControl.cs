using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Integrador.Models;
using System.Text.Json;

namespace Proyecto_Integrador
{

    public partial class PacienteActivoControl : UserControl
    {


        private int idPaciente;

        private string rutaEstado;

        private System.Windows.Forms.Timer timer;
        private Dictionary<string, TimeSpan> tiemposRestantes;

        private Dictionary<string, TimeSpan> tiemposOriginales; // NUEVO

        private List<Label> labelsTiempos = new List<Label>();

        public PacienteActivoControl()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
        }

        public void SetPacienteInfo(int idPaciente ,string nombre, string apellidoPaterno, string apellidoMaterno, int diasInternado, Dictionary<string, TimeSpan> medicamentos)
        {
            lblNombres.Text = "Nombres: " + nombre;
            lblApellidoPaterno.Text = "Apellido Paterno: " + apellidoPaterno;
            lblApellidoMaterno.Text = "Apellido Materno: " + apellidoMaterno;
            lblDiasInternados.Text = "Días Internados: " + diasInternado;

            tiemposRestantes = new Dictionary<string, TimeSpan>(medicamentos);
            labelsTiempos.Clear();
            flpVariable.Controls.Clear(); // Limpia los controles anteriores

            foreach (var med in medicamentos)
            {

                int maxLength = 30;
                string nombreMedicamento = med.Key.Length > maxLength
                    ? med.Key.Substring(0, maxLength) + "..."
                    : med.Key;

                // Label del nombre del medicamento (estilo como lblMedicamento1)
                var lblMed = new Label();
                lblMed.Text = med.Key + ":";
                lblMed.AutoSize = true;
                lblMed.Font = new Font("Segoe UI", 10F);
                lblMed.Margin = new Padding(5, 0, 5, 0);

                // Label del tiempo faltante (estilo como lblTituloTiempoFaltante)
                var lblTiempo = new Label();
                lblTiempo.Text = med.Value.ToString(@"hh\:mm\:ss");
                lblTiempo.AutoSize = true;
                lblTiempo.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
                lblTiempo.Margin = new Padding(5, 0, 5, 0);
                lblTiempo.BackColor = Color.LightGreen;
                lblTiempo.Dock= DockStyle.Left;
                lblTiempo.TextAlign = ContentAlignment.MiddleLeft;

                labelsTiempos.Add(lblTiempo);





                var panel = new TableLayoutPanel();
                panel.ColumnCount = 2;
                panel.RowCount = 1;
                panel.AutoSize = true;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                panel.Controls.Add(lblMed, 0, 0);
                panel.Controls.Add(lblTiempo, 1, 0);

                flpVariable.FlowDirection = FlowDirection.TopDown;
                flpVariable.Controls.Add(panel);




            }
            tiemposOriginales = new Dictionary<string, TimeSpan>(medicamentos);

            this.idPaciente = idPaciente;

            rutaEstado = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $"estado_paciente_{idPaciente}.json"
            );


            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tiemposRestantes == null) return;

            var keys = tiemposRestantes.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];

                if (tiemposRestantes[key] > TimeSpan.Zero)
                {
                    tiemposRestantes[key] = tiemposRestantes[key].Subtract(TimeSpan.FromSeconds(1));
                }
                else
                {
                    // Reinicia el contador al tiempo original
                    tiemposRestantes[key] = tiemposOriginales[key];
                }

                labelsTiempos[i].Text = tiemposRestantes[key].ToString(@"hh\:mm\:ss");

                if (tiemposRestantes[key] <= TimeSpan.FromMinutes(5))
                    labelsTiempos[i].BackColor = Color.Red;
                else if (tiemposRestantes[key] <= TimeSpan.FromMinutes(15))
                    labelsTiempos[i].BackColor = Color.Yellow;
                else
                    labelsTiempos[i].BackColor = Color.LightGreen;
            }
        }



        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            // Lógica para dar de alta al paciente
            MessageBox.Show($"Paciente {lblNombres.Text.Replace("Nombres: ", "")} dado de alta.");
            this.Parent.Controls.Remove(this);
        }

        private void PacienteActivoControl_Load(object sender, EventArgs e)
        {


            var estadoCargado = CargarEstado();
            if (estadoCargado != null)
            {
                tiemposRestantes = estadoCargado;
                ActualizarUIConTiempos();
                timer.Start();
            }


        }

        private void lblTiempoFaltante1_Click(object sender, EventArgs e)
        {

        }


        public void GuardarEstado()
        {
            var estado = new TiempoGuardado
            {
                FechaGuardado = DateTime.Now,
                TiemposRestantes = tiemposRestantes
            };

            var json = JsonSerializer.Serialize(estado);
            File.WriteAllText(rutaEstado, json);
        }

        private Dictionary<string, TimeSpan> CargarEstado()
        {
            if (!File.Exists(rutaEstado))
                return null;

            var json = File.ReadAllText(rutaEstado);
            var estado = JsonSerializer.Deserialize<TiempoGuardado>(json);

            var tiempoTranscurrido = DateTime.Now - estado.FechaGuardado;

            var tiemposAjustados = estado.TiemposRestantes.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value - tiempoTranscurrido > TimeSpan.Zero ? kvp.Value - tiempoTranscurrido : TimeSpan.Zero
            );

            return tiemposAjustados;
        }

        private void ActualizarUIConTiempos()
        {
            labelsTiempos.Clear();
            flpVariable.Controls.Clear();

            foreach (var med in tiemposRestantes)
            {
                var lblMed = new Label
                {
                    Text = med.Key + ":",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F),
                    Margin = new Padding(5, 0, 5, 0)
                };

                var lblTiempo = new Label
                {
                    Text = med.Value.ToString(@"hh\:mm\:ss"),
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                    Margin = new Padding(5, 0, 5, 0),
                    BackColor = Color.LightGreen,
                    Dock = DockStyle.Left,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                labelsTiempos.Add(lblTiempo);

                var panel = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    RowCount = 1,
                    AutoSize = true
                };
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                panel.Controls.Add(lblMed, 0, 0);
                panel.Controls.Add(lblTiempo, 1, 0);

                flpVariable.FlowDirection = FlowDirection.TopDown;
                flpVariable.Controls.Add(panel);
            }
        }

    }
}
