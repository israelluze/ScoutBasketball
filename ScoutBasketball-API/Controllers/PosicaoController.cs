using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoutBasketball_API.Data;
using ScoutBasketball_API.Helpers;
using ScoutBasketball_API.Models;

namespace ScoutBasketball_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicaoController : ControllerBase
    {
        private readonly IDatingRepository _repo;

        public PosicaoController(IDatingRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPosicoes()
        {           

            var posicoes = await _repo.GetPosicoes();            

            Response.AddPagination(posicoes.CurrentPage,posicoes.PageSize,posicoes.TotalCount,posicoes.TotalPages);

            return Ok(posicoes);
        }

        [HttpGet("{id}", Name = "GetPosicao")]
        public async Task<IActionResult> GetPosicao(int id)
        {

            var posicao = await _repo.GetPosicao(id);
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(posicao);
        }  

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosicao(int id, Posicao PosicaoForUpdate) {
            
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) {
            //     return Unauthorized();
            // }

            var posicaoFromRepo = await _repo.GetPosicao(id);

            // _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll()) 
                return NoContent();

            throw new Exception($"Alteração da posição {id} falhou ao salvar") ;
        }  
    }
}