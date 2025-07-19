using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using Proyecto_Integrador.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Integrador.Data
{
    internal class Datos
    {
        //APARTADO REGISTRAR GABRIEL EDUARDO MAY EK
        private string CadenaConexion = "Server=localhost;User=root;Password=admin;Port=3306;database=Proyecto_integrador";

        //Insertar datos en la base de datos
        public int Insertar(string tabla, Dictionary<string, object> datos)
        {
            if (datos == null || datos.Count == 0)
            {
                MessageBox.Show("No se proporcionaron datos para insertar.");
                return -1;
            }

            string columnas = string.Join(",", datos.Keys);
            string valores = "@" + string.Join(",@", datos.Keys);
            string consulta = $"INSERT INTO {tabla} ({columnas}) VALUES ({valores}); SELECT LAST_INSERT_ID();";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
   
                foreach (var dato in datos)
         
                {
                    comando.Parameters.AddWithValue("@" + dato.Key, dato.Value);
                }

                try
                {
                    conexion.Open();
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar en {tabla}: {ex.Message}");
                    return -1;
                }
            }
        }

        public void ActualizarTablas(string tabla, Dictionary<string, object> datos, string condicion, int id_necesario)
        {
            if (datos == null || datos.Count == 0)
            {
                Console.WriteLine("No se proporcionaron datos para actualizar.");
                return;
            }
            var lista = new List<string>();
            foreach (var dato in datos)
            {
                lista.Add($"{dato.Key} = @{dato.Key}");
            }
            string columnas = string.Join(", ", lista);
            string consulta = $"UPDATE {tabla} SET {columnas} WHERE {condicion} = @{condicion}";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                foreach (var dato in datos)
                {
                    comando.Parameters.AddWithValue("@" + dato.Key, dato.Value);
                }
                comando.Parameters.AddWithValue("@" + condicion, id_necesario);
                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar {ex.Message}");
                }
            }
        }


        public void ActualizarTablasConMasCondiciones(string tabla, Dictionary<string, object> valoresActualizar, Dictionary<string, object> condiciones)
        {
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();

                // Construir SET
                var setClause = string.Join(", ", valoresActualizar.Select(kv => $"{kv.Key} = @{kv.Key}"));
                // Construir WHERE
                var whereClause = string.Join(" AND ", condiciones.Select(kv => $"{kv.Key} = @cond_{kv.Key}"));

                string query = $"UPDATE {tabla} SET {setClause} WHERE {whereClause}";

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    // Parámetros para SET
                    foreach (var kv in valoresActualizar)
                    {
                        comando.Parameters.AddWithValue($"@{kv.Key}", kv.Value ?? DBNull.Value);
                    }

                    // Parámetros para WHERE
                    foreach (var kv in condiciones)
                    {
                        comando.Parameters.AddWithValue($"@cond_{kv.Key}", kv.Value ?? DBNull.Value);
                    }

                    comando.ExecuteNonQuery();
                }
            }
        }



        public void CargarComboMedicamentos(ComboBox comboBox)
        {
            // Método para cargar un ComboBox con los nombres de los medicamentos desde la base de datos
            string query = "SELECT id_medicamentos,nombre_medicamento FROM medicamento";
            List<Medicamento> listaMedicamentos = new List<Medicamento>();
            //list es una colección genérica que almacena objetos de tipo Medicamento
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaMedicamentos.Add(new Medicamento
                        {

                            Id = reader.GetInt32("id_medicamentos"),
                            //siempre se debe obtener el ID del medicamento para poder usarlo más tarde 
                            Nombre = reader.GetString("nombre_medicamento")
                            // Obtener el nombre del medicamento desde el lector de datos
                        });
                    }
                    listaMedicamentos.Insert(0, new Medicamento
                    {
                        Id = 0,// Agregar un elemento al inicio de la lista con ID 0 y nombre "Seleccione un medicamento..."
                        Nombre = "selecione un medicamento..."
                    });
                    comboBox.DataSource = listaMedicamentos;// Asignar la lista de medicamentos como fuente de datos del ComboBox
                    comboBox.DisplayMember = "Nombre"; // Lo que se muestra
                    comboBox.ValueMember = "Id"; // El valor asociado
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los medicamentos: {ex.Message}");
                }
            }
        }


        public void CargarComboMedicos(ComboBox comboBox)
        {
            // Método para cargar un ComboBox con los nombres de los médicos desde la base de datos
            string query = "SELECT * FROM datos_del_medico";
            List<Medico> listaMedicos = new List<Medico>();
            // Lista para almacenar los médicos obtenidos de la base de datos
            //Medico es una clase que representa a un médico con sus propiedades
            //list es una colección genérica que almacena objetos de tipo Medico
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaMedicos.Add(new Medico
                        {
                            id_medico = reader.GetInt32("id_medico"),
                            cedula = reader.GetInt32("cedula"),
                            nombres = reader.GetString("nombres"),
                            apellido_materno = reader.GetString("apellido_materno"),
                            apellido_paterno = reader.GetString("apellido_paterno"),

                        });
                    }
                    listaMedicos.Insert(0, new Medico
                    {
                        nombres = "selecione un medico..."
                    });
                    comboBox.DataSource = listaMedicos;// Asignar la lista de médicos como fuente de datos del ComboBox
                    comboBox.DisplayMember = "Nombre_completo"; // Lo que se muestra donde se utiliza la propiedad nombreCompleto de la clase Medico
                    comboBox.ValueMember = "id_medico"; // El valor asociado donde se utiliza la propiedad id_medico de la clase Medico
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los médicos: {ex.Message}");
                }
            }
        }

        public void CargarComboCausas(ComboBox comboBox)
        {
            string query = "select * from causas";
            List<Causas> Lcausas = new List<Causas>();
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Lcausas.Add(new Causas
                        {
                            Id_causas = reader.GetInt32("id_causas"),
                            causa = reader.GetString("causas")

                        });
                    }
                    Lcausas.Insert(0, new Causas { causa = "Seleccione ..." });

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar  las causas :{ex.Message}");
                }
                comboBox.DataSource = Lcausas;
                comboBox.DisplayMember = "causa";
                comboBox.ValueMember = "Id_causas";

            }

        }

        // Método para obtener el ID de un paciente inactivo por su CURP
        public int id_inactivo(string curp)//
        {
            int id_obtenido;
            string query = $"select id_Paciente from paciente where estado_actual = 0 and curp='{curp}'";
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand commandos = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    id_obtenido = Convert.ToInt32(commandos.ExecuteScalar());
                    // ExecuteScalar es un método que ejecuta la consulta y devuelve el primer valor de la primera fila del resultado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar 1", ex.Message);
                    return -1;
                }
                return Convert.ToInt32(id_obtenido);
            }
        }

        // Método para obtener el estado actual de un paciente por su CURP
        public int EstadoActual(string curp)//
        {
          
            string query = $"select estado_actual from paciente where curp='{curp}'";
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand commandos = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    object id_obtenido = commandos.ExecuteScalar();
                    if (id_obtenido == null || id_obtenido == DBNull.Value)
                    {
                        // CURP no encontrado: paciente nuevo
                        return -1;
                    }
                    return Convert.ToInt32(id_obtenido);
                    // ExecuteScalar es un método que ejecuta la consulta y devuelve el primer valor de la primera fila del resultado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar 1", ex.Message);
                    return -1;
                }
            }
        }



        // Método para obtener el CURP de un paciente inactivo por su ID
        public string curp_inactivo(int id)//
        {
            string curp = "";
            string query = $"select curp from paciente where estado_actual = 0 and id_paciente={id}";
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand commandos = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    object obtenerCurp = commandos.ExecuteScalar();
                    if (obtenerCurp != null)
                    {
                        curp = obtenerCurp.ToString();
                        // ExecuteScalar es un método que ejecuta la consulta y devuelve el primer valor de la primera fila del resultado
                    }
                    else
                    {
                        curp = "curp no encontrada";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar 2", ex.Message);
                }
                return curp;
            }
        }
        // Método para obtener los datos de un paciente por su CURP y estado actual
        public Paciente ObtenerDatosPaciente(string curp, int Estado)
        {
            Paciente datos = null;

            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = $"SELECT * FROM paciente WHERE estado_actual={Estado} and curp = '{curp}'";

                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@curp", curp);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                datos = new Paciente
                                {
                                    id_Paciente = reader.GetInt32("id_paciente"),
                                    Nombres = reader.GetString("nombres"),
                                    Curp = reader.GetString("curp"),
                                    Apellido_Paterno = reader.GetString("apellido_Paterno"),
                                    Apellido_Materno = reader.GetString("apellido_materno"),
                                    estado_actual = reader.GetInt32("estado_actual")
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar 3", ex.Message);
                    }
                }
            }

            return datos;
        }
        // Método para obtener la última estancia de un paciente por su ID
        public Estancias ObtenerEstancias(int id)
        {
            Estancias estancias = null;
            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = $"select * from estancias where id_paciente={id} ORDER BY fecha_entrada DESC LIMIT 1;";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                estancias = new Estancias
                                {
                                    Id = reader.GetInt32("id_estadia"),
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar 4", ex.Message);
                    }
                }
            }
            return estancias;
        }

        // Método para obtener el tratamiento asociado a una estancia por su ID
        public Tratamiento ObtenerTratamiento(int id)
        {
            Tratamiento datos =null;

            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                try
                {
                    string query = $"SELECT * FROM tratamiento WHERE id_estancia ={id}";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                datos = new Tratamiento
                                {
                                    id_tratamiento = reader.GetInt32("id_tratamiento"),
                                    estudio_clinico = reader.GetInt32("estudio_clinico")
                                    // Aquí puedes agregar más propiedades según tu modelo

                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el tratamiento: " + ex.Message);
                }
            }

            return datos;
        }


        // Método para obtener los medicamentos asociados a un tratamiento por su ID
        public List<Tratamiento_medicamento> ObtenertratamientoConMedicamentos(int id)
        {
            var medicamentos = new List<Medicamento>();
            var tratamientos = new List<Tratamiento_medicamento>();

            using (var conn = new MySqlConnection(CadenaConexion))
            {
                conn.Open();

                // Obtener medicamentos de su tabla
                using (var cmd = new MySqlCommand("select * from medicamento", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicamentos.Add(new Medicamento
                        {
                            Id = reader.GetInt32("id_medicamentos"),
                            Nombre = reader.GetString("nombre_medicamento")
                        });
                    }
                }

                // Obtener datos del tratamiento  haciendo relacion con la tabla medicamentos para los nombres
                using (var cmd = new MySqlCommand($"SELECT * from tratamiento_medicamento where id_tratamiento = {id}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dato = new Tratamiento_medicamento
                        {

                            id_tratamiento = reader.GetInt32("id_tratamiento"),
                            id_medicamento = reader.GetInt32("id_medicamento"),
                            cantidad = reader.GetInt32("cantidad"),
                            tiempoAdministracion = reader.GetInt32("tiempo_administracion"),
                            UsoActualmente = reader.GetString("Uso_Actualmente"),
                            Efecto_secundario = reader.GetString("efecto_secundario")

                        };

                        // Relacionar con producto
                        dato.Medicamento = medicamentos.FirstOrDefault(p => p.Id == dato.id_medicamento);
                        tratamientos.Add(dato);
                    }
                }
            }

            return tratamientos;
        }
























        // Método para verificar si un paciente tiene una estancia activa
        public bool EstanciaActiva(int idPaciente)
        {
            bool activa = false;
            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM estancias WHERE id_paciente = {idPaciente} AND fecha_salida='2000-01-01 00:00:00'";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        int resultado = Convert.ToInt32(command.ExecuteScalar());
                        activa = resultado == 1 ;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar estancia activa", ex.Message);
                    }
                }
            }
            return activa;
        }


       

        //APARTADO HISTORIAL

    }
}


