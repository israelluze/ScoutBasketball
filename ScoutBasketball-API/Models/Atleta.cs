using System;

namespace ScoutBasketball_API.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }  
        public Posicao Posicao { get; set; }  
        public int PosicaoId { get; set; }    
        public string PhotoUrl { get; set; }

    }
}