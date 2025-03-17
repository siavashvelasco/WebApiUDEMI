using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionController : ControllerBase
	{
		public OurDbContext _db { get; set; }

		public RegionController(OurDbContext db)
		{
			_db = db;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var regions = _db.RegionSet.ToList();
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
				return Ok(region);
			}
		}
		[HttpPost]
		public IActionResult Create([FromBody] CreatedRegionDTO createdRegionDTO)
		{
			var region = new Region()
			{
				Code = createdRegionDTO.Code,
				Name = createdRegionDTO.Name,
				RegionImgUrl = createdRegionDTO.RegionImgUrl
			};
			_db.RegionSet.Add(region);
			_db.SaveChanges();

			var regionDTO = new RegionDTO()
			{
				Id = region.Id,
				Code = region.Code,
				Name = region.Name,
				RegionImgUrl = region.RegionImgUrl
			};
			return CreatedAtAction(nameof(Get), new { idddd = regionDTO.Id }, regionDTO);




		}
	}
}
