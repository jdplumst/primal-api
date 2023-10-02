using Microsoft.AspNetCore.Mvc;
using PrimalAPI.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.Controllers
{
	[ApiController]
	[Route("api/rarity")]
	public class RarityController : ControllerBase
	{
		private readonly IRarityRepository _rarityRepository;
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IResourceMaker _resourceMaker;
		private readonly ILogger<RarityController> _logger;

		public RarityController(
		  IRarityRepository rarityRepository,
		  IPokemonRepository pokemonRepository,
		  IResourceMaker resourceMaker,
		  ILogger<RarityController> logger
		)
		{
			_rarityRepository = rarityRepository;
			_pokemonRepository = pokemonRepository;
			_resourceMaker = resourceMaker;
			_logger = logger;
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type = typeof(RarityDto))]
		public IActionResult GetRarityById(int id)
		{
			_logger.LogInformation($"Getting Rarity by Id {id}");
			var rarity = _rarityRepository.GetRarityById(id);
			if (rarity == null)
			{
				_logger.LogWarning($"Rarity with Id {id} was not found");
				return NotFound();
			}
			var pokemons = _pokemonRepository.GetPokemonByHabitatId(id);
			var pokemonList = _resourceMaker.CreatePokemonResources(pokemons);
			return Ok(new RarityDto(id, rarity.Name, rarity.Description, pokemonList));
		}
	}
}