using System.Data;

namespace Negocio
{
    public class ResultadoOperacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int IdGenerado { get; set; }
        public DataTable Datos { get; set; }

        public static ResultadoOperacion Ok(string mensaje, int id = 0, DataTable datos = null)
        {
            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = mensaje,
                IdGenerado = id,
                Datos = datos
            };
        }

        public static ResultadoOperacion Error(string mensaje)
        {
            return new ResultadoOperacion
            {
                Exito = false,
                Mensaje = mensaje
            };
        }
    }
}
