using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
	public class OurDbContext : DbContext
	{
		public DbSet<Difficulty> DifficultySet { get; set; }
		public DbSet<Region> RegionSet { get; set; }
		public DbSet<Walk> WalkSet { get; set; }
		public OurDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{

		}
	}
}
