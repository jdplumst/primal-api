using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Queries;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("/api/habitat")]
    public class HabitatController : ControllerBase
    {
        private readonly IHabitatRepository _habitatRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<HabitatController> _logger;

        public HabitatController(
            IHabitatRepository habitatRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<HabitatController> logger)
        {
            _habitatRepository = habitatRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(HabitatDto))]
        public IActionResult GetHabitatById(int id)
        {
            _logger.LogInformation($"Getting Habitat by Id {id}");
            var habitat = _habitatRepository.GetHabitatById(id);
            if (habitat == null)
            {
                _logger.LogWarning($"Habitat with Id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByHabitatId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new HabitatDto(id, habitat.Name, habitat.Description, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(HabitatDto))]
        public IActionResult GetHabitatByName(string name)
        {
            _logger.LogInformation($"Getting Habitat by Name {name}");
            var habitat = _habitatRepository.GetHabitatByName(name);
            if (habitat == null)
            {
                _logger.LogWarning($"Habitat with name {name} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonByHabitatName(name);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new HabitatDto(habitat.Id, habitat.Name, habitat.Description, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<HabitatDto>>))]
        public IActionResult GetAllHabitats([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation($"Getting all Habitats on page {paginationQuery.PageNumber} " +
            "with {paginationQuery.PageSize} items");
            var habitats = _habitatRepository.GetHabitats(paginationQuery);
            var habitatDtos = new List<HabitatDto>();
            foreach (var habitat in habitats)
            {
                var pokemons = _pokemonRepository.GetPokemonByHabitatId(habitat.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                habitatDtos.Add(new HabitatDto(habitat.Id, habitat.Name, habitat.Description, pokemonList));
            }
            var infoDto = new InfoDto(paginationQuery, _habitatRepository.GetHabitatCount());
            return Ok(new PageDto<ICollection<HabitatDto>>(habitatDtos, infoDto));
        }
    }
}
