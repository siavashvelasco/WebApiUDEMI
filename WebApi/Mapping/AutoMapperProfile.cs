using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.Mapping
{
	public class AutoMapperProfile: Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Region, CreateRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
            CreateMap<Walk,CreateWalkDto>().ReverseMap();
            CreateMap<WalkDto,Walk>().ReverseMap();
        }
    }
}
