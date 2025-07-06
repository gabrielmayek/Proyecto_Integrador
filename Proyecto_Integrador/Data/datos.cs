using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Proyecto_Integrador.models;

namespace Proyecto_Integrador.Data
{
    internal class Datos
    {
        private string CadenaConexion = "Server=localhost;User=root;Password=admin;Port=3306;database=Proyecto_integrador";
        // Cambia la cadena de conexión según tu configuración
        public void PruebaConexcion()// Método para probar la conexión a la base de datos
        {
            MySqlConnection conexion = new MySqlConnection(CadenaConexion);// Crear una nueva conexión a la base de datos
            try
            {
                conexion.Open();// Abrir la conexión
            }
            catch (Exception ex)// Capturar cualquier excepción que ocurra al intentar abrir la conexión
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message} ");
                // Mostrar un mensaje de error si la conexión falla
                return;
                // Salir del método si la conexión falla
            }
            conexion.Close();// Cerrar la conexión después de probarla
        }

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
                    // Ejecutar la consulta y obtener el último ID insertado como un entero
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar en {tabla}: {ex.Message}");
                    return -1;
                }
            }










        }
        public void CargarCombo(ComboBox comboBox)
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
                        Id = 0,
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
            string query = "SELECT id_medico,cedula,nombres,apellido_paterno,apellido_materno FROM datos_del_medico";
            List<Medico> listaMedicos = new List<Medico>();
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
                            apellido_paterno = reader.GetString("apellido_paterno"),
                            apellido_materno = reader.GetString("apellido_materno")
                        });
                    }
                    listaMedicos.Insert(0, new Medico
                    { 
                        nombres = "selecione un medico..."
                    });
                    comboBox.DataSource = listaMedicos;// Asignar la lista de médicos como fuente de datos del ComboBox
                    comboBox.DisplayMember = "nombreCompleto"; // Lo que se muestra
                    comboBox.ValueMember = "id_medico"; // El valor asociado
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los médicos: {ex.Message}");
                }
            }
        }
    }
}