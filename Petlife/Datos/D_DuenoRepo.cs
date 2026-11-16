
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_DuenoRepo : D_Conexion
    {
        // Obtiene los dueños registrados.
        public static DataTable ListarDuenos()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT d.id_dueno, u.id_usuario, u.nombre
                               FROM dueno d
                               INNER JOIN usuario u
                               ON d.id_usuario = u.id_usuario
                               WHERE u.activo = 1
                               ORDER BY u.nombre";

                using (MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(sql, conexion))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
