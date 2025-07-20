using Proyecto_Integrador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
namespace Proyecto_Integrador
{

    public partial class PacienteActivoControl : UserControl
    {


        private int idPaciente;
        private string rutaEstado;
        private System.Windows.Forms.Timer timer;
        private Dictionary<string, TimeSpan> tiemposRestantes;
        private Dictionary<string, TimeSpan> tiemposOriginales;
        private List<Label> labelsTiempos = new List<Label>();

        public PacienteActivoControl()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
        }

        public void SetPacienteInfo(int id, string nombre, string apellidoPaterno, string apellidoMaterno, int diasInternado, Dictionary<string, TimeSpan> medicamentos)
        {
            lblNombres.Text = "Nombres: " + nombre;
            lblApellidoPaterno.Text = "Apellido Paterno: " + apellidoPaterno;
            lblApellidoMaterno.Text = "Apellido Materno: " + apellidoMaterno;
            lblDiasInternados.Text = "Días Internados: " + diasInternado;

            idPaciente = id;
            rutaEstado = ObtenerRutaEstado(idPaciente);

            var estadoCargado = CargarEstado();

            tiemposRestantes = new Dictionary<string, TimeSpan>(medicamentos);

            if (estadoCargado != null)
            {
                foreach (var kvp in estadoCargado)
                {
                    if (tiemposRestantes.ContainsKey(kvp.Key))
                    {
                        tiemposRestantes[kvp.Key] = kvp.Value;
                    }
                }
            }

            tiemposOriginales = new Dictionary<string, TimeSpan>(medicamentos);

            labelsTiempos.Clear();
            flpVariable.Controls.Clear();

            foreach (var med in tiemposRestantes)
            {
                int maxLength = 30;
                string nombreMedicamento = med.Key.Length > maxLength
                    ? med.Key.Substring(0, maxLength) + "..."
                    : med.Key;

                var lblMed = new Label
                {
                    Text = nombreMedicamento + ":",
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

        private string ObtenerRutaEstado(int id)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $"estado_paciente_{id}.json"
            );
        }

        private Dictionary<string, TimeSpan> CargarEstado()
        {
            if (File.Exists(rutaEstado))
            {
                string json = File.ReadAllText(rutaEstado);
                var estado = JsonSerializer.Deserialize<TiempoGuardado>(json);

                if (estado != null)
                {
                    TimeSpan tiempoTranscurrido = DateTime.Now - estado.FechaGuardado;

                    // Restar el tiempo transcurrido a cada medicamento
                    var tiemposAjustados = estado.TiemposRestantes.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value - tiempoTranscurrido > TimeSpan.Zero
                            ? kvp.Value - tiempoTranscurrido
                            : TimeSpan.Zero
                    );

                    return tiemposAjustados;
                }
            }

            return null;
        }




        public void GuardarEstado()
        {
            var estado = new TiempoGuardado
            {
                TiemposRestantes = tiemposRestantes,
                FechaGuardado = DateTime.Now
            };

            string json = JsonSerializer.Serialize(estado);
            File.WriteAllText(rutaEstado, json);
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Paciente {lblNombres.Text.Replace("Nombres: ", "")} dado de alta.");
            this.Parent.Controls.Remove(this);
        }

        private void PacienteActivoControl_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de carga si es necesario
        }







    }
}
