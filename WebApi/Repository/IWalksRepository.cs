using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Repository
{
	public interface IWalksRepository
	{
		public Task<Walk> CreateAsync(Walk id);
		public Task<Walk> UpdateAsync(Guid id,Walk walk);
		public Task<Walk> DeleteAsync(Guid walk);
		public Task<List<Walk>> GetAllAsync();
		public Task<Walk> GetAsync(Guid id);
	}
}
