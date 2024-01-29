using System.Data.SqlTypes;

namespace Prueba.Models
{
    public class SolicitudDetalle
    {
        public int IdSolicitudDetalle (get; set;)

        public int IdInsumo(get; set;)

        public int IdSolicitud(get; set;)

        public int IdStock(get; set;)

        public int Cantidad(get; set;)

        public SqlMoney PrecioUnitario(get; set;)
            
        public SqlMoney SubTotal(get; set;)

        public DateTime FechaRegistro(get; set;)

        public bool EstadoRegistro(get; set;)
    }
}
