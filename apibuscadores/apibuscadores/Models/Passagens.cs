using System.ComponentModel.DataAnnotations;

namespace apibuscadores.Models
{
    public class Passagens
    {
        [Key] 
        public int IdPassagem { get; set; }
        public int IdVoo { get; set; }
        
    }
}
