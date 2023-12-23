using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
	public class UserDbContext : DbContext
	{
		public DbSet<UserDTO> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("CONNECTION_STRING"), new MySqlServerVersion(new Version(8, 2, 0)));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserDTO>()
				.HasKey(u => u.Id);

			modelBuilder.Entity<UserDTO>()
				.HasIndex(u => u.Subject)
				.IsUnique();

			modelBuilder.Entity<UserDTO>()
				.HasIndex(u => u.Id)
				.IsUnique();
		}
	}

}
