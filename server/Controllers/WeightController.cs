using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/weight")]
    public class WeightController : ControllerBase
    {
        private readonly IWeightRepository _weightRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;

        public WeightController(IWeightRepository weightRepository, IPokemonRepository pokemonRepository, IResourceMaker resourceMaker)
        {
            _weightRepository = weightRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(WeightDto))]
        public IActionResult GetWeightById(int id)
        {
            var weight = _weightRepository.GetWeightById(id);
            if (weight == null)
            {
                return NotFound();
            }
            var pokemon = _pokemonRepository.GetPokemonByWeightId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemon);
            return Ok(new WeightDto(id, weight.Name, weight.Range, pokemonList));
        }
    }
}
