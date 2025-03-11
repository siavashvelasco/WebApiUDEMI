using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
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
	}
}
