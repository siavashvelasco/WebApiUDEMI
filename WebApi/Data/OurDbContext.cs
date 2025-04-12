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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			var difficultyList = new List<Difficulty>{
				new Difficulty() { Id = Guid.Parse("ce49d50e-9205-47d3-bacd-76188a374a0b"), Name = "Easy" },
				new Difficulty() { Id = Guid.Parse("90eb3b13-245e-4a4a-b339-182262e47fd3"), Name = "Medium" },
				new Difficulty() { Id = Guid.Parse("e6063157-694d-42d7-bbc1-9a3286fbe820"), Name = "Hard" }
			};
			modelBuilder.Entity<Difficulty>().HasData(difficultyList);
		}
	}
}
