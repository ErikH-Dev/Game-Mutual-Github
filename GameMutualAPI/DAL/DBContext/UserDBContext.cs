using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
	public class UserDbContext : DbContext
	{
		public DbSet<UserDTO> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=quaking-yoyo-yapping;database=game_mutual", new MySqlServerVersion(new Version(8, 2, 0)));
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
