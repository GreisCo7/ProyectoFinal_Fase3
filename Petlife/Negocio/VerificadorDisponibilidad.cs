using System;
using System.Data;
using Datos;

namespace Negocio
{
    public class VerificadorDisponibilidad
    {
        public ResultadoOperacion Verificar(int idMascota, int idVeterinario, DateTime fechaHora)
        {
            if (fechaHora.Second != 0 || (fechaHora.Minute != 0 && fechaHora.Minute != 30))
                return ResultadoOperacion.Error("La hora debe estar en intervalos exactos de 30 minutos (:00 o :30).");

            DateTime ahora = DateTime.Now;
            if (fechaHora < ahora.AddHours(2))
                return ResultadoOperacion.Error("La cita debe solicitarse con al menos 2 horas de anticipación.");

            if (fechaHora > ahora.AddDays(30))
                return ResultadoOperacion.Error("No se pueden agendar citas con más de 30 días de anticipación.");

            DataTable horarios = D_HorarioRepo.ListarHorarios(idVeterinario, fechaHora.Date);
            bool dentroDeHorario = false;
            TimeSpan horaSolicitada = fechaHora.TimeOfDay;

            foreach (DataRow fila in horarios.Rows)
            {
                TimeSpan inicio = (TimeSpan)fila["hora_inicio"];
                TimeSpan fin = (TimeSpan)fila["hora_fin"];

                if (horaSolicitada >= inicio && horaSolicitada.Add(TimeSpan.FromMinutes(30)) <= fin)
                {
                    dentroDeHorario = true;
                    break;
                }
            }

            if (!dentroDeHorario)
                return ResultadoOperacion.Error("El veterinario no tiene horario de atención disponible en esa fecha y hora.");

            if (D_CitaRepo.HayConflicto(idMascota, idVeterinario, fechaHora))
                return ResultadoOperacion.Error("El horario ya no está disponible o la mascota ya tiene otra cita activa a esa misma hora.");

            return ResultadoOperacion.Ok("Espacio disponible.");
        }
    }
}
