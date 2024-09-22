using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Helpers;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

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

            Skill? skill;
            try
            {
                skill = _skillRepository.GetSkillById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(Constants.DatabaseErrorMsg, e);
                return Problem(Constants.DatabaseErrorMsg);
            }

            if (skill == null)
            {
                _logger.LogWarning($"Skill with Id {id} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonBySkillId(id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new SkillDto(id, skill.Name, skill.Description, pokemonList));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(SkillDto))]
        public IActionResult GetSkillByName(string name)
        {
            _logger.LogInformation($"Getting Skill by Name {name}");
            var skill = _skillRepository.GetSkillByName(name);
            if (skill == null)
            {
                _logger.LogWarning($"Skill with Name {name} was not found");
                return NotFound();
            }
            var pokemons = _pokemonRepository.GetPokemonBySkillId(skill.Id);
            var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
            return Ok(new SkillDto(skill.Id, skill.Name, skill.Description, pokemonList));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PageDto<ICollection<SkillDto>>))]
        public IActionResult GetSkills([FromQuery] PaginationQuery paginationQuery)
        {
            _logger.LogInformation(
                $"Getting all Skills on page {paginationQuery.PageNumber} "
                    + "with {paginationQuery.PageSize} items"
            );
            var skills = _skillRepository.GetSkills(paginationQuery);
            var skillDtos = new List<SkillDto>();
            foreach (var skill in skills)
            {
                var pokemons = _pokemonRepository.GetPokemonBySkillId(skill.Id);
                var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
                skillDtos.Add(new SkillDto(skill.Id, skill.Name, skill.Description, pokemonList));
            }
            var info = new InfoDto(paginationQuery, _skillRepository.GetSkillCount());
            var pageDto = new PageDto<ICollection<SkillDto>>(skillDtos, info);
            return Ok(pageDto);
        }
    }
}
