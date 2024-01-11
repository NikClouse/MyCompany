using Microsoft.EntityFrameworkCore;
using MyCompany.Models;

namespace MyCompany
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Organization> Organizations { get; set; }
		public DbSet<Sotrudnik> Sotrudniks { get; set; }




		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DatabaseContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Sotrudnik>().HasKey(p => p.Id);
			base.OnModelCreating(modelBuilder);
		}


	}
}
