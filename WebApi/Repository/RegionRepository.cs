using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;

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

		public async Task<Region> GetByIdAsync(Guid id)
		{
			return await _db.RegionSet.FindAsync(id);
		}
		public async Task<Region?> CreateAsync(Region region)
		{
			await _db.RegionSet.AddAsync(region);
			await _db.SaveChangesAsync();

			return region;
		}
		


		public async Task<Region?> DeleteAsync(Region region)
		{
			 _db.RegionSet.Remove(region);
			await _db.SaveChangesAsync();

			return region;
		}

public async Task<Region?> UpdateAsync(Guid regionId, Region region)
		{
			var regionModel = await _db.RegionSet.FirstOrDefaultAsync(o => o.Id == regionId);
			if (regionModel == null) {
				return null;
			}

			regionModel.Code = region.Code;
			regionModel.Name = region.Name;
			regionModel.RegionImgUrl = region.RegionImgUrl;
			await _db.SaveChangesAsync();

			return regionModel;
		}
	}
}
