using API.Models.General;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTesting
{
	public class TestDatabaseContext : DbContext
	{
		public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options) : base(options) { }

		public DbSet<UserModel> Users { get; set; }
	}
}
