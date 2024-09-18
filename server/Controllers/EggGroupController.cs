using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Queries;

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
            ILogger<EggGroupController> logger
        )
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
        public IActionResult GetEggGroupByName(string name)
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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<EggGroupDto>>))]
        public IActionResult GetEggGroups([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation(
                $"Getting all Egg Groups on page {paginationQuery.PageNumber} "
                    + "with {paginationQuery.PageSize} items"
            );
            var eggGroups = _eggGroupRepository.GetEggGroups(paginationQuery);
            var eggGroupDtos = new List<EggGroupDto>();
            foreach (var eggGroup in eggGroups)
            {
                var pokemons = _pokemonRepository.GetPokemonByEggGroupId(eggGroup.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                eggGroupDtos.Add(new EggGroupDto(eggGroup.Id, eggGroup.Name, pokemonList));
            }
            var info = new InfoDto(paginationQuery, _eggGroupRepository.GetEggGroupCount());
            var pageDto = new PageDto<ICollection<EggGroupDto>>(eggGroupDtos, info);
            return Ok(pageDto);
        }
    }
}
