using Microsoft.EntityFrameworkCore;
using ScoutBasketball_API.Models;

namespace ScoutBasketball_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){} 

        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
    }
}