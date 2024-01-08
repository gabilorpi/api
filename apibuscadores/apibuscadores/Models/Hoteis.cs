using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Hoteis
    {
        [Key]
        public int IdHotel { get; set; }
        public double PrecoPorNoite { get; set; }
        public string Categorias { get; set; }
        public string NomeHotel { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set;}
        public string Telefone { get; set;}
    }
}
