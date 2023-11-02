using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;

namespace PrimalAPI.Controllers
{
    [ApiController]
    [Route("api/skill")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IResourceMaker _resourceMaker;
        private readonly ILogger<SkillController> _logger;

        public SkillController(
            ISkillRepository skillRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            ILogger<SkillController> logger
        )
        {
            _skillRepository = skillRepository;
            _pokemonRepository = pokemonRepository;
            _resourceMaker = resourceMaker;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SkillDto))]
        public IActionResult GetSkillById(int id)
        {
            _logger.LogInformation($"Getting Skill by Id {id}");
            var skill = _skillRepository.GetSkillById(id);
            if (skill == null)
            {
                _logger.LogWarning($"Skill with Id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonBySkillId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new SkillDto(id, skill.Name, skill.Description, pokemonList));
        }
    }
}