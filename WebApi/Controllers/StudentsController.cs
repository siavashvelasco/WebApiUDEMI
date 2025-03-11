using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetAll()
		{
			Dictionary<string,int> result = new Dictionary<string, int>()
			{
				{"ali",33},
				{"soli",26 },
				{"moli",25 }
			};
			return Ok(result);
		}
	}
}
