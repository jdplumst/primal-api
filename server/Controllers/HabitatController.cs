using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Queries;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/habitat")]
    public class HabitatController : ControllerBase
    {
        private readonly IHabitatRepository _habitatRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;

        public HabitatController(IHabitatRepository habitatRepository, IPokemonRepository pokemonRepository, IResourceMaker resourceMaker)
        {
            _habitatRepository = habitatRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(HabitatDto))]
        public IActionResult GetHabitatById(int id)
        {
            var habitat = _habitatRepository.GetHabitatById(id);
            if (habitat == null)
            {
                return NotFound();
            }
            var pokemonList = new List<ResourceDto>();
            var pokemon = _pokemonRepository.GetPokemonByHabitatId(id);
            foreach (var p in pokemon)
            {
                var resource = _resourceMaker.CreatePokemonResource(p);
                pokemonList.Add(resource);
            }
            return Ok(new HabitatDto(id, habitat.Name, habitat.Description, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(HabitatDto))]
        public IActionResult GetHabitatByName(string name)
        {
            var habitat = _habitatRepository.GetHabitatByName(name);
            if (habitat == null)
            {
                return NotFound();
            }
            var pokemonList = new List<ResourceDto>();
            var pokemon = _pokemonRepository.GetPokemonByHabitatName(name);
            foreach (var p in pokemon)
            {
                var resource = _resourceMaker.CreatePokemonResource(p);
                pokemonList.Add(resource);
            }
            return Ok(new HabitatDto(habitat.Id, habitat.Name, habitat.Description, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<HabitatDto>>))]
        public IActionResult GetAllHabitats([FromQuery] PaginationQuery paginationQuery)
        {
            var habitats = _habitatRepository.GetHabitats(paginationQuery);
            var habitatDtos = new List<HabitatDto>();
            foreach (var habitat in habitats)
            {
                var pokmemonList = new List<ResourceDto>();
                var pokemon = _pokemonRepository.GetPokemonByHabitatId(habitat.Id);
                foreach (var p in pokemon)
                {
                    var resource = _resourceMaker.CreatePokemonResource(p);
                    pokmemonList.Add(resource);
                }
                habitatDtos.Add(new HabitatDto(habitat.Id, habitat.Name, habitat.Description, pokmemonList));
            }
            var infoDto = new InfoDto(paginationQuery.PageNumber, paginationQuery.PageSize, _habitatRepository.GetHabitatCount());
            return Ok(new PageDto<ICollection<HabitatDto>>(habitatDtos, infoDto));
        }
    }
}
