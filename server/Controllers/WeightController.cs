using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Queries;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("/api/weight")]
    public class WeightController : ControllerBase
    {
        private readonly IWeightRepository _weightRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<WeightController> _logger;

        public WeightController(
            IWeightRepository weightRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<WeightController> logger)
        {
            _weightRepository = weightRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(WeightDto))]
        public IActionResult GetWeightById(int id)
        {
            _logger.LogInformation($"Getting Weight by Id {id}");
            var weight = _weightRepository.GetWeightById(id);
            if (weight == null)
            {
                _logger.LogWarning($"Weight with Id {id} was not found");
                return NotFound();
            }
            var pokemon = _pokemonRepository.GetPokemonByWeightId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemon);
            return Ok(new WeightDto(id, weight.Name, weight.Range, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(WeightDto))]
        public IActionResult GetWeightByName(string name)
        {
            _logger.LogInformation($"Getting Weight by Name {name}");
            var weight = _weightRepository.GetWeightByName(name);
            if (weight == null)
            {
                _logger.LogWarning($"Size with name {name} was not found");
                return NotFound();
            }
            var pokemon = _pokemonRepository.GetPokemonByWeightName(name);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemon);
            return Ok(new WeightDto(weight.Id, weight.Name, weight.Range, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<WeightDto>>))]
        public IActionResult GetWeights([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation($"Getting all Weights on page {paginationQuery.PageNumber} " +
            "with {paginationQuery.PageSize} items");
            var weights = _weightRepository.GetWeights(paginationQuery);
            var weightDtos = new List<WeightDto>();
            foreach (var weight in weights)
            {
                var pokemons = _pokemonRepository.GetPokemonBySizeId(weight.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                weightDtos.Add(new WeightDto(weight.Id, weight.Name, weight.Range, pokemonList));
            }
            var info = new InfoDto(paginationQuery, _weightRepository.GetWeightCount());
            var pageDto = new PageDto<ICollection<WeightDto>>(weightDtos, info);
            return Ok(pageDto);
        }
    }
}
