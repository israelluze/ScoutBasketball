using System.Collections.Generic;
using System.Threading.Tasks;
using ScoutBasketball_API.Helpers;
using ScoutBasketball_API.Models;

namespace ScoutBasketball_API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Atleta>> GetAtletas(AtletaParams atletaParams);
        Task<Atleta> GetAtleta(int id);

        Task<PagedList<Posicao>> GetPosicoes();
        Task<Posicao> GetPosicao(int id);
    }
}