using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using Proyecto_Integrador.Models;

namespace Proyecto_Integrador.Data
{
    internal class Datos
    {
        private string CadenaConexion = "Server=localhost;User=root;Password=admin;Port=3306;database=Proyecto_integrador";
        // Cambia la cadena de conexión según tu configuración
        // Método para insertar datos en una tabla específica de la base de datos
        //Dictionario que contiene los nombres de las columnas y sus valores
        //Dictionary es una colección de clave-valor, donde cada clave es un nombre de columna y su valor es el valor a insertar en esa columna
        //datos es un diccionario que contiene los nombres de las columnas y sus valores
        // Método genérico para insertar datos y devolver el ID generado
        public int Insertar(string tabla, Dictionary<string, object> datos)
        {
            if (datos == null || datos.Count == 0)
            {
                MessageBox.Show("No se proporcionaron datos para insertar.");
                return -1;
            }
            // Unir las claves del diccionario en una cadena separada por comas
            // Join es un método que une los elementos de una colección en una sola cadena,
            // separándolos por el delimitador especificado
            // En este caso, se unen las claves del diccionario en una cadena separada por comas
            string columnas = string.Join(",", datos.Keys);
            //un string.Join es un método que une los elementos de una colección en una sola cadena,
            // separándolos por el delimitador especificado
            // En este caso, se unen las claves del diccionario en una cadena separada por comas

            //Keys es una propiedad del diccionario que devuelve una colección de las claves del diccionario
            // Unir las claves del diccionario en una cadena separada por comas, precedidas por '@' para usarlas como parámetros
            // @ es un prefijo que indica que se trata de un parámetro en la consulta SQL
            // Esto es útil para evitar inyecciones SQL y mejorar la seguridad de la consulta
            string valores = "@" + string.Join(",@", datos.Keys);
            //datos.Keys es una colección de las claves del diccionario, que son los nombres de las columnas
            // Crear una cadena de consulta SQL para insertar los datos en la tabla especificada
            string consulta = $"INSERT INTO {tabla} ({columnas}) VALUES ({valores}); SELECT LAST_INSERT_ID();";


            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                // Crear un nuevo comando SQL con la consulta y la conexión
                foreach (var dato in datos)
                // Recorrer cada par clave-valor en el diccionario
                {
                    comando.Parameters.AddWithValue("@" + dato.Key, dato.Value);
                    // Agregar el parámetro al comando con el valor correspondiente
                    // AddWithValue es un método que agrega un parámetro
                    // al comando con el nombre y el valor especificados
                    //Value es una propiedad del parámetro que contiene el valor del parámetro
                }

                try
                {
                    conexion.Open();
                    return Convert.ToInt32(comando.ExecuteScalar());
                    //ExecuteScalar es un método que ejecuta la consulta
                    //y devuelve el primer valor de la primera fila del resultado
                    // Ejecutar la consulta y obtener el último ID insertado como un entero
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar en {tabla}: {ex.Message}");
                    return -1;
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
                MySqlCommand command = new MySqlCommand(query,connection);
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
                catch(Exception ex) 
                {
                    MessageBox.Show($"Error al cargar  las causas :{ex.Message}");
                }
                comboBox.DataSource= Lcausas;
                comboBox.DisplayMember = "causa";
                comboBox.ValueMember = "Id_causas";

            }
        
        }

        public int[] ObtenerId()
        {
            string query = "SELECT * FROM datos_personales where estado_actual = 1";
            List<int> tablas = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand commandos = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = commandos.ExecuteReader();
                    while (reader.Read())
                    {
                        tablas.Add(reader.GetInt32("id_paciente"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar", ex.Message);
                }
                return tablas.ToArray();
            }
        }

        public int EstadoActual()//determina el número de pacientes activos
        {
            int total = 0;
            string query = "select count(*) from datos_personales where estado_actual = 1";
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand commandos = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    total = Convert.ToInt32(commandos.ExecuteScalar());
                    // ExecuteScalar es un método que ejecuta la consulta y devuelve el primer valor de la primera fila del resultado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar", ex.Message);
                    return -1;
                }
                return Convert.ToInt32(total);
            }

        }
    




        public Paciente ObtenerDatosPaciente(string curp)
        {
            Paciente datos = null;

            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = "SELECT * FROM paciente WHERE estado_actual=0";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@curp", curp);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datos = new Paciente
                            {
                                id_Paciente= reader.GetInt32("id_paciente"),
                                Nombres = reader.GetString("nombres"),
                                Curp = reader.GetString("curp"),
                                Apellido_Paterno = reader.GetString("apellido_Paterno"),
                                Apellido_Materno = reader.GetString("apellido_materno"),
                                estado_actual = reader.GetInt32("estado_actual")
                            };
                        }
                    }
                }
            }

            return datos;
        }

        public Estancias OBtenerEstancias(int id)
        {
            Estancias estancias = null;
            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = $"select * from estancias where id_paciente={id}";
                using(var command = new MySqlCommand(query,connection))
                {
                    using(var reader = command.ExecuteReader())
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
            }


            return estancias;
        }




        public Tratamiento ObtenerTratamiento(int id)
        {
            Tratamiento datos = null;

            using (var connection = new MySqlConnection(CadenaConexion))
            {
                connection.Open();
                string query = $"SELECT * FROM tratamiento WHERE id_estancia ={id} ";
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

                            };
                        }
                    }
                }
            }

            return datos;
        }
     


            public List<Tratamiento_medicamento> ObtenertratamientoConMedicamentos(int id)
            {
                var medicamentos = new List<Medicamento>();
                var tratamientos = new List<Tratamiento_medicamento>();

                using (var conn = new MySqlConnection(CadenaConexion))
                {
                    conn.Open();

                    // Obtener productos
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

                    // Obtener datos médicos
                    using (var cmd = new MySqlCommand($"SELECT * from tratamiento_medicamento where id_tratamiento = {id}", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        var dato = new Tratamiento_medicamento
                        {

                            id_tratamiento = reader.GetInt32("id_tratamiento"),
                            id_medicaemto= reader.GetInt32("id_medicamento"),
                            cantidad = reader.GetInt32("cantidad"),
                            tiempoAdministracion=reader.GetInt32("tiempo_administracion"),
                            Efecto_secundario=reader.GetString("efecto_secundario")

                        };

                            // Relacionar con producto
                            dato.Medicamento = medicamentos.FirstOrDefault(p => p.Id == dato.id_medicaemto);

                            tratamientos.Add(dato);
                        }
                    }
                }

                return tratamientos;
            }
        }









    
}


