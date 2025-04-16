namespace WebApi.Models.DTOs
{
    public class CreateWalkDto
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public double LenghthInKm { get; set; }
		public string? WalkImgUrl { get; set; }
		public Guid RegionId { get; set; }
		public Guid DifficultyId { get; set; }


	}
}