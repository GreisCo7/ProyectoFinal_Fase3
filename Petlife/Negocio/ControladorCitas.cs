using System;
using System.Data;
using Datos;

namespace Negocio
{
    public class ControladorCitas
    {
        private readonly DisponibilidadService _disponibilidadService = new DisponibilidadService();
        private readonly CitaService _citaService = new CitaService();

        public DataTable ListarDuenos()
        {
            return D_DuenoRepo.ListarDuenos();
        }

        public DataTable ListarMascotasPorDueno(int idDueno)
        {
            return D_MascotaRepo.ListarMascotas(idDueno);
        }

        public DataTable ListarVeterinarios()
        {
            return D_VeterinarioRepo.ListarVeterinarios();
        }

        public DataTable ConsultarHorariosDisponibles(int idVeterinario, DateTime fecha)
        {
            return _disponibilidadService.ObtenerEspaciosDisponibles(idVeterinario, fecha);
        }

        public ResultadoOperacion VerificarYRegistrarCita(
            int idDueno,
            int idMascota,
            int idVeterinario,
            DateTime fechaHora,
            string motivo,
            int idUsuarioRegistrador)
        {
            return _citaService.SolicitarCita(
                idDueno,
                idMascota,
                idVeterinario,
                fechaHora,
                motivo,
                idUsuarioRegistrador,
                validarPropiedadDueno: true
            );
        }
    }
}
