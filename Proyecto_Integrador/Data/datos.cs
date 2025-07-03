using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_Integrador.Data
{
    internal class datos
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
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message} ");// Mostrar un mensaje de error si la conexión falla
                return;// Salir del método si la conexión falla
            }
            conexion.Close();// Cerrar la conexión después de probarla
            MessageBox.Show("Conexión exitosa a la base de datos.");// Mostrar un mensaje de éxito si la conexión se abre correctamente
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

            string columnas = string.Join(",", datos.Keys);// Unir las claves del diccionario en una cadena separada por comas
            string valores = "@" + string.Join(",@", datos.Keys);// Unir las claves del diccionario en una cadena separada por comas, precedidas por '@' para usarlas como parámetros
            string consulta = $"INSERT INTO {tabla} ({columnas}) VALUES ({valores}); SELECT LAST_INSERT_ID();";
            // Crear la consulta SQL para insertar los datos y obtener el último ID insertado

            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);// Crear un nuevo comando SQL con la consulta y la conexión
                foreach (var dato in datos)// Recorrer cada par clave-valor en el diccionario
                {
                    comando.Parameters.AddWithValue("@" + dato.Key, dato.Value);// Agregar el parámetro al comando con el valor correspondiente
                }

                try
                {
                    conexion.Open();
                    return Convert.ToInt32(comando.ExecuteScalar());// Ejecutar la consulta y obtener el último ID insertado como un entero
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar en {tabla}: {ex.Message}");
                    return -1;
                }
            }










        }
        public void CargarCombo()
        {
            // Método para cargar un ComboBox con los nombres de los medicamentos desde la base de datos
            string query = "select nombre from medicamento";
            using (MySqlConnection connection = new MySqlConnection(CadenaConexion))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nombreMedicamento = reader.GetString(0);
                        // Aquí puedes agregar el nombre del medicamento al ComboBox
                        // comboBoxMedicamentos.Items.Add(nombreMedicamento);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los medicamentos: {ex.Message}");
                }
            }


        }



    }
}