using AutoMapper;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Mapping
{
	public class AutoMapperProfile: Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Region, CreatedRegionDTO>().ReverseMap();
            CreateMap<Region, UpdatedRegionDTO>().ReverseMap();
        }
    }
}
