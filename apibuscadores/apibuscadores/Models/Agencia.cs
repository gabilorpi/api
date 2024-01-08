using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Agencia
    {
        [Key]

        public int IdAgencia { get; set; }
        public string NomeAgencia { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }

    }
}
