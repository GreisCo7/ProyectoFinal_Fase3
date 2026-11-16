
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_MascotaRepo : D_Conexion
    {
        // Consulta las mascotas de un dueño.
        public static DataTable ListarMascotas(int idDueno)
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT id_mascota, nombre, especie, raza
                               FROM mascota
                               WHERE id_dueno = @idDueno
                               ORDER BY nombre";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idDueno", idDueno);

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // Comprueba si la mascota pertenece al dueño.
        public static bool PerteneceADueno(int idMascota, int idDueno)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"SELECT COUNT(*) FROM mascota
                               WHERE id_mascota = @idMascota
                               AND id_dueno = @idDueno";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idMascota", idMascota);
                    cmd.Parameters.AddWithValue("@idDueno", idDueno);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}

