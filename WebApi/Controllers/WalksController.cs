using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Repository;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WalksController : ControllerBase
	{
		public IWalksRepository WalksRepo { get; set; }
		public IMapper Mapper { get; set; }
		public WalksController(IWalksRepository walksRepo, IMapper mapper)
		{
			WalksRepo = walksRepo;
			Mapper = mapper;
		}

		//post:
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateWalkDto walksCreated)
		{
			var walkModel = Mapper.Map<Walk>(walksCreated);
			var walk = await WalksRepo.CreateAsync(walkModel);
			var walkDto = Mapper.Map<WalkDto>(walk);
			return Ok(walkDto);

		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var allWalks = await WalksRepo.GetAllAsync();
			return Ok(allWalks);
		}
		[HttpGet]
		[Route("{idForGet:Guid}")]
		public async Task<IActionResult> Get([FromRoute] Guid idForGet)
		{
			var walkModel = await WalksRepo.GetAsync(idForGet);
			if (walkModel == null)
			{
				return NotFound();
			}
			var walkDto = Mapper.Map<WalkDto>(walkModel);
			return Ok(walkDto);
		}

		[HttpPut]
		[Route("{idForUpdate:Guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid idForGet, CreateWalkDto createdWalkDto)
		{
			var walkModel = Mapper.Map<Walk>(createdWalkDto);
			walkModel = await WalksRepo.UpdateAsync(idForGet, walkModel);
			if (walkModel == null)
			{
				return NotFound();
			}
			var walkDto = Mapper.Map<WalkDto>(createdWalkDto);
			return Ok(walkDto);
		}
		[HttpDelete]
		[Route("{idForDelete:Guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid idForDelete)
		{
			var existingWalk = await WalksRepo.DeleteAsync(idForDelete);
			if (existingWalk == null)
			{
				return NotFound();
			}
			return Ok(existingWalk);

		}


	}
}
