using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
	public class RegionRepository : IRegionRepository
	{


		public OurDbContext _db;

		public RegionRepository(OurDbContext ourDbContext)
		{
			_db = ourDbContext;
		}

		public async Task<List<Region>> GetAllAsync()
		{
			return await _db.RegionSet.ToListAsync();
		}
	}
}
