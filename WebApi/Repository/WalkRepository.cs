using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
	public class WalkRepository : IWalksRepository
	{
		public OurDbContext _db { get; set; }

		public WalkRepository(OurDbContext db)
		{
			_db = db;
		}


		public async Task<Walk> CreateAsync(Walk walk)
		{
			await _db.WalkSet.AddAsync(walk);
			await _db.SaveChangesAsync();
			return walk;
		}

		public async Task<Walk> DeleteAsync(Guid id)
		{
			var existingWalk = await _db.WalkSet.FindAsync(id);
			if (existingWalk == null) { return null; }
			_db.WalkSet.Remove(existingWalk);
			await _db.SaveChangesAsync();
			return existingWalk;

		}

		public async Task<List<Walk>> GetAllAsync()
		{
			var walksList = await _db.WalkSet.ToListAsync();
			return walksList;
		}

		public async Task<Walk> GetAsync(Guid id)
		{
			var walk = await _db.WalkSet.FindAsync(id);
			return walk;
		}

		public async Task<Walk> UpdateAsync(Guid id, Walk walk)
		{
			var walkModel = await _db.WalkSet.FindAsync(id);
			if (walkModel == null)
			{
				return null;
			}
			walkModel.Name = walk.Name;
			walkModel.Description = walk.Description;
			walkModel.LenghthInKm = walk.LenghthInKm;
			walkModel.WalkImgUrl = walk.WalkImgUrl;
			return walkModel;

		}
	}
}
