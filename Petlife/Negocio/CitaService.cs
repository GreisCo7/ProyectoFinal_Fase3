using System;
using System.Data;
using Datos;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class CitaService
    {
        private readonly VerificadorDisponibilidad _verificador = new VerificadorDisponibilidad();

        public ResultadoOperacion SolicitarCita(
            int idDueno,
            int idMascota,
            int idVeterinario,
            DateTime fechaHora,
            string motivo,
            int idUsuarioRegistrador,
            bool validarPropiedadDueno = true)
        {
            if (idMascota <= 0)
                return ResultadoOperacion.Error("Debe seleccionar una mascota.");

            if (idVeterinario <= 0)
                return ResultadoOperacion.Error("Debe seleccionar un veterinario.");

            if (string.IsNullOrWhiteSpace(motivo))
                return ResultadoOperacion.Error("El motivo de la cita es obligatorio.");

            if (motivo.Trim().Length > 200)
                return ResultadoOperacion.Error("El motivo no puede exceder los 200 caracteres.");

            if (validarPropiedadDueno && !D_MascotaRepo.PerteneceADueno(idMascota, idDueno))
                return ResultadoOperacion.Error("La mascota seleccionada no pertenece al dueño indicado.");

            ResultadoOperacion validacion = _verificador.Verificar(idMascota, idVeterinario, fechaHora);
            if (!validacion.Exito)
                return validacion;

            try
            {
                int idCita = D_CitaRepo.RegistrarCita(
                    idMascota,
                    idVeterinario,
                    fechaHora,
                    motivo.Trim(),
                    idUsuarioRegistrador
                );

                DataTable detalle = D_CitaRepo.ObtenerDetalleCita(idCita);
                return ResultadoOperacion.Ok("Cita registrada exitosamente.", idCita, detalle);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                return ResultadoOperacion.Error("El horario acaba de ser ocupado por otra solicitud. Por favor seleccione otro espacio.");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Error("Error al registrar la cita: " + ex.Message);
            }
        }
    }
}
