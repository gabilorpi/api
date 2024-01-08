using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Contatos
    {
        [Key]
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagen { get; set; }
    }
}
