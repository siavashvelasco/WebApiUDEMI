using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		public RegionController(OurDbContext db,IRegionRepository regionRepository)
		{
			_db = db;
			RegionRepository = regionRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var regions = await RegionRepository.GetAllAsync();
			var regionDTO = new List<RegionDTO>();
			foreach (var region in regions)
			{
				regionDTO.Add(new RegionDTO { Id = region.Id, Code = region.Code, Name = region.Name, RegionImgUrl = region.RegionImgUrl });
			}
			return Ok(regionDTO);
		}


		[HttpGet]
		[Route("{idddd:guid}")]
		public IActionResult Get([FromRoute] Guid idddd)
		{
			var region = _db.RegionSet.Find(idddd);
			if (region == null)
			{
				return NotFound();
			}
			else
			{
				RegionDTO regionDTO = new RegionDTO() { Id = region.Id, Code = region.Code, Name = region.Name, RegionImgUrl = region.RegionImgUrl };
				return Ok(regionDTO);
			}
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatedRegionDTO createdRegionDTO)
		{
			var region = new Region()
			{
				Code = createdRegionDTO.Code,
				Name = createdRegionDTO.Name,
				RegionImgUrl = createdRegionDTO.RegionImgUrl
			};
			await _db.RegionSet.AddAsync(region);
			await _db.SaveChangesAsync();

			var regionDTO = new RegionDTO()
			{
				Id = region.Id,
				Code = region.Code,
				Name = region.Name,
				RegionImgUrl = region.RegionImgUrl
			};
			return CreatedAtAction(nameof(Get), new { idddd = regionDTO.Id }, regionDTO);




		}
		[HttpPut]
		[Route("{ID:Guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid ID, [FromBody] UpdatedRegionDTO updatedRegionDTO)
		{
			var regionModel = _db.RegionSet.Find(ID);
			if (regionModel == null)
			{
				return NotFound();
			}

			regionModel.Code = updatedRegionDTO.Code;
			regionModel.Name = updatedRegionDTO.Name;
			regionModel.RegionImgUrl = updatedRegionDTO.RegionImgUrl;
			await _db.SaveChangesAsync();

			var regionDto = new RegionDTO()
			{
				Id = regionModel.Id,
				Code = regionModel.Code,
				Name = regionModel.Name,
				RegionImgUrl = regionModel.RegionImgUrl
			};
			return Ok(regionDto);
		}

		[HttpDelete]
		[Route("{ID:Guid}")]

		public async Task<IActionResult> Delete([FromRoute] Guid ID)
		{
			var regionModel = _db.RegionSet.Find(ID);
			if (regionModel == null)
			{
				return NotFound();
			}
			_db.RegionSet.Remove(regionModel);
			await _db.SaveChangesAsync();
			return Ok();
		}
	}
}
