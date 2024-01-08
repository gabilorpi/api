using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public List<Agencia> Agencia { get; set; }
    }
}
