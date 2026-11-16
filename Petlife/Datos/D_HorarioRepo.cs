
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_HorarioRepo : D_Conexion
    {
        // Consulta los horarios de un veterinario.
        public static DataTable ListarHorarios(int idVeterinario, DateTime fecha)
        {
            DataTable tabla = new DataTable();

            int diaSemana = ((int)fecha.DayOfWeek + 6) % 7 + 1;

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                string sql = @"SELECT id_horario, dia_semana,
                                      hora_inicio, hora_fin
                               FROM horario_atencion
                               WHERE id_veterinario = @idVeterinario
                               AND dia_semana = @diaSemana
                               ORDER BY hora_inicio";

                using (MySqlCommand cmd =
                    new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@idVeterinario", idVeterinario);
                    cmd.Parameters.AddWithValue("@diaSemana", diaSemana);

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
