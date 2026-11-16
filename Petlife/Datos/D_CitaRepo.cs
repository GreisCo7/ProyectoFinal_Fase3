
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_CitaRepo : D_Conexion
    {
        // Consulta las citas activas de un veterinario.
        public static DataTable ListarCitasActivas(int idVeterinario, DateTime fecha)
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT id_cita, id_mascota, fecha_hora
                               FROM cita
                               WHERE id_veterinario = @idVeterinario
                               AND fecha_hora >= @fecha
                               AND fecha_hora < DATE_ADD(@fecha, INTERVAL 1 DAY)
                               AND ocupa_espacio = 1
                               ORDER BY fecha_hora";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idVeterinario", idVeterinario);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // Comprueba si existe una cita en el mismo horario.
        public static bool HayConflicto(int idMascota, int idVeterinario,
            DateTime fechaHora)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"SELECT COUNT(*) FROM cita
                               WHERE fecha_hora = @fechaHora
                               AND ocupa_espacio = 1
                               AND (id_veterinario = @idVeterinario
                               OR id_mascota = @idMascota)";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idMascota", idMascota);
                    cmd.Parameters.AddWithValue("@idVeterinario", idVeterinario);
                    cmd.Parameters.AddWithValue("@fechaHora", fechaHora);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // Registra una nueva cita.
        public static int RegistrarCita(int idMascota, int idVeterinario,
            DateTime fechaHora, string motivo, int idUsuario)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"INSERT INTO cita
                               (id_mascota, id_veterinario, fecha_hora,
                                motivo, registrada_por)
                               VALUES
                               (@idMascota, @idVeterinario, @fechaHora,
                                @motivo, @idUsuario)";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idMascota", idMascota);
                    cmd.Parameters.AddWithValue("@idVeterinario", idVeterinario);
                    cmd.Parameters.AddWithValue("@fechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(cmd.LastInsertedId);
                }
            }
        }

        // Consulta los datos de una cita registrada.
        public static DataTable ObtenerDetalleCita(int idCita)
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT id_cita, mascota, veterinario,
                                      fecha_hora, motivo, estado
                               FROM vw_cita_detalle
                               WHERE id_cita = @idCita";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCita", idCita);

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}
