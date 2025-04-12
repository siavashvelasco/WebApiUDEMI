using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Repository
{
	public interface IRegionRepository
	{

		public Task<List<Region>> GetAllAsync() ;
		public Task<Region> GetByIdAsync(Guid id);
		public Task<Region> CreateAsync(Region region);
		public Task<Region> DeleteAsync(Region region);
		public Task<Region> UpdateAsync(Guid regionId, Region region);
	}
}
