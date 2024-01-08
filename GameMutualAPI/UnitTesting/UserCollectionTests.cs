using FluentAssertions;
using Logic;
using Logic.Interface;
using Moq;
using UnitTesting.Models;

namespace UnitTesting
{
	[TestClass]
	public class UserCollectionTests
	{
		private Mock<IUserCollection> _mockUserCollection;
		private UserCollection _userCollection;

		[TestInitialize]
		public void TestInitialize()
		{
			_mockUserCollection = new Mock<IUserCollection>();
			_userCollection = new UserCollection(_mockUserCollection.Object);
		}

		[TestMethod]
		public async Task Create_ShouldReturnUser()
		{
			var user = new UserTestModel();
			_mockUserCollection.Setup(x => x.Create(user)).ReturnsAsync(user);

			var result = await _userCollection.Create(user);

			result.Should().Be(user);
		}

		[TestMethod]
		public async Task Read_ShouldReturnUser()
		{
			var user = new UserTestModel();
			_mockUserCollection.Setup(x => x.Read(It.IsAny<int>())).ReturnsAsync(user);

			var result = await _userCollection.Read(1);

			result.Should().Be(user);
		}

		[TestMethod]
		public async Task ReadByToken_ShouldReturnUser()
		{
			var user = new UserTestModel();
			_mockUserCollection.Setup(x => x.ReadByToken(It.IsAny<string>())).ReturnsAsync(user);

			var result = await _userCollection.ReadByToken("token");

			result.Should().Be(user);
		}

		[TestMethod]
		public async Task Update_ShouldReturnUser()
		{
			var user = new UserTestModel();
			_mockUserCollection.Setup(x => x.Update(user)).ReturnsAsync(user);

			var result = await _userCollection.Update(user);

			result.Should().Be(user);
		}

		[TestMethod]
		public async Task Delete_ShouldReturnTrue()
		{
			_mockUserCollection.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

			var result = await _userCollection.Delete(1);

			result.Should().BeTrue();
		}

		[TestMethod]
		public async Task AddSteamId_ShouldReturnTrue()
		{
			_mockUserCollection.Setup(x => x.AddSteamId(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

			var result = await _userCollection.AddSteamId(1, "steamId");

			result.Should().BeTrue();
		}
	}
}
