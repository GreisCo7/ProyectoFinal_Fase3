
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_VeterinarioRepo : D_Conexion
    {
        public static DataTable ListarVeterinarios()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT id_veterinario, nombre, especialidad
                               FROM vw_veterinario
                               WHERE activo = 1
                               ORDER BY nombre";

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

