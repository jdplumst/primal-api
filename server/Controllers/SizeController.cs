using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Models;
using server.Queries;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/size")]
    public class SizeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SizeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SizeDto))]
        public IActionResult GetSize(int id)
        {
            var size = _dataContext.Size.Find(id);
            if (size == null)
            {
                return NotFound();
            }
            var sizeDto = new SizeDto();
            sizeDto.Id = id;
            sizeDto.Name = size.Name;
            sizeDto.Space = size.Space;
            sizeDto.Pokemon = new List<PokemonResourceDto>();
            var pokemon = _dataContext.Pokemon.Where(p => p.SizeId == id);
            foreach (var p in pokemon)
            {
                var pokemonResourceDto = new PokemonResourceDto();
                pokemonResourceDto.Name = p.Name;
                pokemonResourceDto.Url =
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                  ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/pokemon/" + p.Id
                  : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/pokemon/" + p.Id;
                sizeDto.Pokemon.Add(pokemonResourceDto);
            }
            return Ok(sizeDto);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<SizeDto>))]
        public IActionResult GetAllSizes([FromQuery] PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            var sizes = _dataContext.Size.Skip(skip).Take(paginationQuery.PageSize).ToList();
            var sizeDtos = new List<SizeDto>();
            foreach (var size in sizes)
            {
                var sizeDto = new SizeDto();
                sizeDto.Id = size.Id;
                sizeDto.Name = size.Name;
                sizeDto.Space = size.Space;
                sizeDto.Pokemon = new List<PokemonResourceDto>();
                var pokemon = _dataContext.Pokemon.Where(p => p.SizeId == size.Id);
                foreach (var p in pokemon)
                {
                    var pokemonResourceDto = new PokemonResourceDto();
                    pokemonResourceDto.Name = p.Name;
                    pokemonResourceDto.Url =
                        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                      ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/pokemon/" + p.Id
                      : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/pokemon/" + p.Id;
                    sizeDto.Pokemon.Add(pokemonResourceDto);
                }
                sizeDtos.Add(sizeDto);
            }
            var info = new InfoDto(paginationQuery.PageNumber, paginationQuery.PageSize);
            if (paginationQuery.PageNumber > 1)
            {
                info.PreviousPage =
                        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                      ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/size?pageNumber=" + (paginationQuery.PageNumber - 1) + "&pageSize=" + paginationQuery.PageSize
                      : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/size?pageNumber=" + (paginationQuery.PageNumber - 1) + "&pageSize=" + paginationQuery.PageSize;
            }
            if (skip + paginationQuery.PageSize < _dataContext.Size.Count())
            {
                info.NextPage =
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                      ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/size?pageNumber=" + (paginationQuery.PageNumber + 1) + "&pageSize=" + paginationQuery.PageSize
                      : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/size?pageNumber=" + (paginationQuery.PageNumber + 1) + "&pageSize=" + paginationQuery.PageSize;
            }
            var pageDto = new PageDto<ICollection<SizeDto>>(sizeDtos, info);
            return Ok(pageDto);
        }
    }
}
