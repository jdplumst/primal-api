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

        public SizeController(ISizeRepository sizeRepository, IPokemonRepository pokemonRepository, IResourceMaker resourceMaker)
        {
            _sizeRepository = sizeRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SizeDto))]
        public IActionResult GetSizeById(int id)
        {
            var size = _sizeRepository.GetSizeById(id);
            if (size == null)
            {
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
            var size = _sizeRepository.GetSizeByName(name);
            if (size == null)
            {
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
