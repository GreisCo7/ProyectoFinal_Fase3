using System;
using System.Collections.Generic;
using System.Data;
using Datos;

namespace Negocio
{
    public class DisponibilidadService
    {
        public DataTable ObtenerEspaciosDisponibles(int idVeterinario, DateTime fecha)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("id_veterinario", typeof(int));
            resultado.Columns.Add("veterinario", typeof(string));
            resultado.Columns.Add("especialidad", typeof(string));
            resultado.Columns.Add("fecha_hora", typeof(DateTime));
            resultado.Columns.Add("hora_texto", typeof(string));

            DateTime ahora = DateTime.Now;
            DateTime limiteMinimo = ahora.AddHours(2);
            DateTime limiteMaximo = ahora.AddDays(30);

            if (fecha.Date > limiteMaximo.Date || fecha.Date < ahora.Date)
                return resultado;

            DataTable veterinarios = D_VeterinarioRepo.ListarVeterinarios();

            foreach (DataRow vet in veterinarios.Rows)
            {
                int vetId = Convert.ToInt32(vet["id_veterinario"]);
                if (idVeterinario > 0 && vetId != idVeterinario)
                    continue;

                string nombreVet = vet["nombre"].ToString();
                string especialidad = vet["especialidad"].ToString();

                DataTable horarios = D_HorarioRepo.ListarHorarios(vetId, fecha.Date);
                if (horarios.Rows.Count == 0)
                    continue;

                DataTable citasActivas = D_CitaRepo.ListarCitasActivas(vetId, fecha.Date);
                HashSet<DateTime> ocupados = new HashSet<DateTime>();
                foreach (DataRow cita in citasActivas.Rows)
                {
                    ocupados.Add(Convert.ToDateTime(cita["fecha_hora"]));
                }

                foreach (DataRow bloque in horarios.Rows)
                {
                    TimeSpan horaInicio = (TimeSpan)bloque["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)bloque["hora_fin"];

                    DateTime actual = fecha.Date.Add(horaInicio);
                    DateTime fin = fecha.Date.Add(horaFin);

                    while (actual.AddMinutes(30) <= fin)
                    {
                        if (actual >= limiteMinimo && actual <= limiteMaximo && !ocupados.Contains(actual))
                        {
                            resultado.Rows.Add(
                                vetId,
                                nombreVet,
                                especialidad,
                                actual,
                                actual.ToString("HH:mm")
                            );
                        }
                        actual = actual.AddMinutes(30);
                    }
                }
            }

            DataView dv = resultado.DefaultView;
            dv.Sort = "fecha_hora ASC, veterinario ASC";
            return dv.ToTable();
        }
    }
}
