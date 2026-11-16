using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_PruebaConexion
    {
        public static void ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion =
                    new MySqlConnection(D_Conexion.cadenaConexion))
                {
                    conexion.Open();

                    Console.WriteLine("Conexión exitosa con la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}