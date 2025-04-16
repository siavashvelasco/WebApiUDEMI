using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Repository;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionController : ControllerBase
	{
		public OurDbContext _db { get; set; }
		public IRegionRepository RegionRepository { get; set; }
		public IMapper Mapper { get; }

		public RegionController(OurDbContext db, IRegionRepository regionRepository, IMapper mapper)
		{
			_db = db;
			RegionRepository = regionRepository;
			Mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var regions = await RegionRepository.GetAllAsync();
			var regionDTO = Mapper.Map<List<RegionDTO>>(regions);

			return Ok(regionDTO);
		}


		[HttpGet]
		[Route("{idddd:guid}")]
		public async Task<IActionResult> Get([FromRoute] Guid idddd)
		{
			var region = await RegionRepository.GetByIdAsync(idddd);
			if (region == null)
			{
				return NotFound();
			}

			RegionDTO regionDTO = Mapper.Map<RegionDTO>(region);
			return Ok(regionDTO);

		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateRegionDTO createdRegionDTO)
		{

			var region = Mapper.Map<Region>(createdRegionDTO);
			region = await RegionRepository.CreateAsync(region);


			var regionDTO = Mapper.Map<RegionDTO>(region);

			return CreatedAtAction(nameof(Get), new { idddd = regionDTO.Id }, regionDTO);




		}
		[HttpPut]
		[Route("{ID:Guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid ID, [FromBody] UpdateRegionDTO updatedRegionDTO)
		{
			var region = Mapper.Map<Region>(updatedRegionDTO);
			var regionModel = await RegionRepository.UpdateAsync(ID, region);
			if (regionModel == null)
			{
				return NotFound();
			}



			var regionDto = Mapper.Map<RegionDTO>(regionModel);
			return Ok(regionDto);
		}

		[HttpDelete]
		[Route("{ID:Guid}")]

		public async Task<IActionResult> Delete([FromRoute] Guid ID)
		{
			var regionModel = await RegionRepository.DeleteAsync(ID);
			if (regionModel == null)
			{
				return NotFound();
			}
			var regionDto = Mapper.Map<RegionDTO>(regionModel);
			return Ok(regionDto);
		}
	}
}
