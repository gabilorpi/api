using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Reserva_Quarto
    {
        [Key]
        public int IdReserva { get; set; }
        public int Quarto { get; set; }
        public string DataCheckOut { get; set; }
        public string DataCheckIn { get; set; }
    }
}
