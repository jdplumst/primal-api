using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Queries;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("api/rarity")]
    public class RarityController : ControllerBase
    {
        private readonly IRarityRepository _rarityRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<RarityController> _logger;

        public RarityController(
            IRarityRepository rarityRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<RarityController> logger
        )
        {
            _rarityRepository = rarityRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(RarityDto))]
        public IActionResult GetRarityById(int id)
        {
            _logger.LogInformation($"Getting Rarity by Id {id}");
            var rarity = _rarityRepository.GetRarityById(id);
            if (rarity == null)
            {
                _logger.LogWarning($"Rarity with Id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByRarityId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new RarityDto(id, rarity.Name, rarity.Description, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(RarityDto))]
        public IActionResult GetRarityByName(string name)
        {
            _logger.LogInformation($"Getting Rarity by Name {name}");
            var rarity = _rarityRepository.GetRarityByName(name);
            if (rarity == null)
            {
                _logger.LogWarning($"Rarity with Name {name} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByRarityId(rarity.Id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new RarityDto(rarity.Id, rarity.Name, rarity.Description, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<RarityDto>>))]
        public IActionResult GetRarities([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation(
                $"Getting all Rarities on page {paginationQuery.PageNumber} "
                    + "with {paginationQuery.PageSize} items"
            );
            var rarities = _rarityRepository.GetRarities(paginationQuery);
            var rarityDtos = new List<RarityDto>();
            foreach (var rarity in rarities)
            {
                var pokemons = _pokemonRepository.GetPokemonByRarityId(rarity.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                rarityDtos.Add(
                    new RarityDto(rarity.Id, rarity.Name, rarity.Description, pokemonList)
                );
            }
            var info = new InfoDto(paginationQuery, _rarityRepository.GetRarityCount());
            var pageDto = new PageDto<ICollection<RarityDto>>(rarityDtos, info);
            return Ok(pageDto);
        }
    }
}
