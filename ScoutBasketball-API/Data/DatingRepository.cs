using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoutBasketball_API.Helpers;
using ScoutBasketball_API.Models;

namespace ScoutBasketball_API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;           
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Atleta> GetAtleta(int id)
        {
            var atleta = await _context.Atletas.FirstOrDefaultAsync(x => x.Id == id);            
            return atleta;
        }

        public async Task<Posicao> GetPosicao(int id)
        {
            var posicao = await _context.Posicoes.FirstOrDefaultAsync(x => x.Id == id);            
            return posicao;
        }

        public async Task<PagedList<Atleta>> GetAtletas(AtletaParams atletaParams)
        {
            var atletas = _context.Atletas.Include(x => x.Posicao)
                .OrderByDescending(u => u.Numero).AsQueryable();

            atletas = atletas.Where(u => u.Id != atletaParams.AtletaId);

            if (atletaParams.Posicao != null) {
                atletas = atletas.Where(u => u.Posicao.NomePosicao == atletaParams.Posicao); 
            }
           

            if (atletaParams.AnoMin != 1950 || atletaParams.Anomax != 2099) {

                atletas = atletas.Where(u => u.DataNascimento.Year >= atletaParams.NumeroMin  && u.DataNascimento.Year <= atletaParams.NumeroMax);
            } 

            if (!string.IsNullOrEmpty(atletaParams.OrderBy)) {
                switch (atletaParams.OrderBy){
                    case "created":
                        atletas = atletas.OrderByDescending(u => u.Numero);
                        break;
                        default:
                        atletas  = atletas.OrderByDescending(u => u.DataNascimento);
                        break;
                }
            }   


            return await PagedList<Atleta>.CreateAsync(atletas,atletaParams.PageNumber,atletaParams.PageSize);
        }

         public async Task<PagedList<Posicao>> GetPosicoes()
        {
            var posicoes = _context.Posicoes
                .OrderByDescending(u => u.NomePosicao).AsQueryable();  

            return await PagedList<Posicao>.CreateAsync(posicoes,1,10);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}