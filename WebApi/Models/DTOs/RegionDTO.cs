﻿namespace WebApi.Models.DTOs
{
	public class RegionDTO
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string? RegionImgUrl { get; set; }
	}
}
