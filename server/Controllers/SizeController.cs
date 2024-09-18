using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Helpers;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("/api/size")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<SizeController> _logger;

        public SizeController(
            ISizeRepository sizeRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<SizeController> logger
        )
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
            _logger.LogInformation($"Getting Size by Id {id}");

            Size? size;

            try
            {
                size = _sizeRepository.GetSizeById(id);
            }
            catch (Exception e)
            {
                _logger.LogInformation(Constants.DatabaseErrorMsg, e);
                return Problem(Constants.DatabaseErrorMsg);
            }

            if (size == null)
            {
                _logger.LogWarning($"Size with Id {id} was not found");
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
            _logger.LogInformation($"Getting Size by Name {name}");

            Size? size;

            try
            {
                size = _sizeRepository.GetSizeByName(name);
            }
            catch (Exception e)
            {
                _logger.LogInformation(Constants.DatabaseErrorMsg, e);
                return Problem(Constants.DatabaseErrorMsg);
            }
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
            _logger.LogInformation(
                $"Getting all Sizes on page {paginationQuery.PageNumber} "
                    + "with {paginationQuery.PageSize} items"
            );

            ICollection<Size> sizes;

            try
            {
                sizes = _sizeRepository.GetSizes(paginationQuery);
            }
            catch (Exception e)
            {
                _logger.LogWarning(Constants.DatabaseErrorMsg, e);
                return Problem(Constants.DatabaseErrorMsg);
            }

            var sizeDtos = new List<SizeDto>();

            foreach (var size in sizes)
            {
                var pokemons = _pokemonRepository.GetPokemonBySizeId(size.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                sizeDtos.Add(new SizeDto(size.Id, size.Name, size.Space, pokemonList));
            }

            var info = new InfoDto(paginationQuery, _sizeRepository.GetSizeCount());
            var pageDto = new PageDto<ICollection<SizeDto>>(sizeDtos, info);
            return Ok(pageDto);
        }
    }
}
