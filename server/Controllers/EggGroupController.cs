using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("api/egg-group")]
    public class EggGroupController : ControllerBase
    {
        private readonly IEggGroupRepository _eggGroupRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<EggGroupController> _logger;

        public EggGroupController(
            IEggGroupRepository eggGroupRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<EggGroupController> logger)
        {
            _eggGroupRepository = eggGroupRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(EggGroupDto))]
        public IActionResult GetEggGroupById(int id)
        {
            _logger.LogInformation($"Getting Egg Group by Id {id}");
            var eggGroup = _eggGroupRepository.GetEggGroupById(id);
            if (eggGroup == null)
            {
                _logger.LogWarning($"Egg Group with Id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByEggGroupId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new EggGroupDto(id, eggGroup.Name, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(EggGroupDto))]
        public IActionResult GetRarityByName(string name)
        {
            _logger.LogInformation($"Getting Egg Group by Name {name}");
            var eggGroup = _eggGroupRepository.GetEggGroupByName(name);
            if (eggGroup == null)
            {
                _logger.LogWarning($"Egg Group with Name {name} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByEggGroupId(eggGroup.Id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new EggGroupDto(eggGroup.Id, eggGroup.Name, pokemonList));
        }
    }
}