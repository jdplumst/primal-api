using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Models;

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
    }
}
