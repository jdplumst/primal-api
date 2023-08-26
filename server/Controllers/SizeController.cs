using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Queries;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/size")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<SizeController> _logger;

        public SizeController(ISizeRepository sizeRepository, IPokemonRepository pokemonRepository, IResourceMaker resourceMaker, ILogger<SizeController> logger)
        {
            _sizeRepository = sizeRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SizeDto))]
        public IActionResult GetSizeById(int id)
        {
            _logger.LogInformation("Getting Size by Id");
            var size = _sizeRepository.GetSizeById(id);
            if (size == null)
            {
                _logger.LogWarning($"Size with id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonBySizeId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new SizeDto(id, size.Name, size.Space, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(SizeDto))]
        public IActionResult GetSizeByName(string name)
        {
            _logger.LogInformation("Getting Size by Name");
            var size = _sizeRepository.GetSizeByName(name);
            if (size == null)
            {
                _logger.LogWarning($"Size with name {name} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonBySizeName(name);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new SizeDto(size.Id, size.Name, size.Space, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<SizeDto>>))]
        public IActionResult GetSizes([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation($"Getting all Sizes on page {paginationQuery.PageNumber} with {paginationQuery.PageSize} items");
            var sizes = _sizeRepository.GetSizes(paginationQuery);
            var sizeDtos = new List<SizeDto>();
            foreach (var size in sizes)
            {
                var pokemons = _pokemonRepository.GetPokemonBySizeId(size.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                sizeDtos.Add(new SizeDto(size.Id, size.Name, size.Space, pokemonList));
            }
            var info = new InfoDto(paginationQuery.PageNumber, paginationQuery.PageSize, _sizeRepository.GetSizeCount());
            var pageDto = new PageDto<ICollection<SizeDto>>(sizeDtos, info);
            return Ok(pageDto);
        }
    }
}
