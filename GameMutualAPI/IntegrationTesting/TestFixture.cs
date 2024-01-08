using AutoMapper;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using SharedObjects;

namespace IntegrationTesting
{
	public class TestFixture : IDisposable
	{
		public TestDatabaseContext Context { get; private set; }
		public IMapper Mapper { get; }

		public TestFixture()
		{
			var options = new DbContextOptionsBuilder<TestDatabaseContext>()
				.UseSqlite("Filename=:memory:")
				.Options;

			Context = new TestDatabaseContext(options);
			Context.Database.OpenConnection();
			Context.Database.EnsureCreated();

			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IUser, UserDTO>().ReverseMap()
					.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
				cfg.CreateMap<API.Models.Create.CreateUserModel, API.Models.General.UserModel>()
					.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			});

			Mapper = config.CreateMapper();
		}

		public void Dispose()
		{
			Context.Database.CloseConnection();
			Context.Dispose();
		}
	}
}
