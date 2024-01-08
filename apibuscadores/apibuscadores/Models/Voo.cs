using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Voo
    {
        [Key]
        public int IdVoo { get; set; }
        public string HoraDecolagem { get; set; }
        public string DataDecolagem { get; set; }
        public string HoraAterrissagem {  get; set; }
        public string DataAterrissagem { get; set; } 
        public string Origem {  get; set; }
        public string Destino { get; set; }
        public string Preco { get; set; }
        
    }
}
