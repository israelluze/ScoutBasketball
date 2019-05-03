using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScoutBasketball_API.Data;
using ScoutBasketball_API.Helpers;
using ScoutBasketball_API.Models;

namespace ScoutBasketball_API.Controllers
{       
    [Route("api/[controller]")]
    [ApiController]
    public class AtletasController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public AtletasController(IDatingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAtletas([FromQuery]AtletaParams atletaParams)
        {
            // var currentAtletaId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // var atletaFromRepo = await _repo.GetAtleta(currentAtletaId);

            // atletaParams.AtletaId = currentAtletaId;

            var atletas = await _repo.GetAtletas(atletaParams);            

            Response.AddPagination(atletas.CurrentPage,atletas.PageSize,atletas.TotalCount,atletas.TotalPages);

            return Ok(atletas);
        }

        [HttpGet("{id}", Name = "GetAtleta")]
        public async Task<IActionResult> GetAtleta(int id)
        {

            var user = await _repo.GetAtleta(id);
            //var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(user);
        }  

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAtleta(int id, Atleta AtletaForUpdate) {
            
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) {
            //     return Unauthorized();
            // }

            var atletaFromRepo = await _repo.GetAtleta(id);

            // _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll()) 
                return NoContent();

            throw new Exception($"Alteração do atleta {id} falhou ao salvar") ;
        }           
    }
}