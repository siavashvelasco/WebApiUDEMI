using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Repository
{
	public interface IRegionRepository
	{

		public Task<List<Region>> GetAllAsync() ;


	}
}
