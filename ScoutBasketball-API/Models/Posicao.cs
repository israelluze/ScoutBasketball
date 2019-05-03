using System.Collections.Generic;

namespace ScoutBasketball_API.Models
{
    public class Posicao
    {
        public int Id { get; set; }
        public string NomePosicao { get; set; }
        public ICollection<Atleta> Atletas { get; set; }
    }
}