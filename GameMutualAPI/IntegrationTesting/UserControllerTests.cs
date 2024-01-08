using API.Controllers;
using API.Models.Create;
using API.Models.General;
using AutoMapper;
using FluentAssertions;
using Logic;
using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedObjects;
using Xunit;

namespace IntegrationTesting
{
	public class UserControllerTests : IClassFixture<TestFixture>
	{
		private readonly TestFixture _fixture;
		private readonly UserController _controller;
		private readonly Mock<IUserCollection> _mockUserCollection;
		private readonly IMapper _mapper;
		private readonly UserCollection _userCollection;

		public UserControllerTests(TestFixture fixture)
		{
			_fixture = fixture;
			_mockUserCollection = new Mock<IUserCollection>();
			_userCollection = new UserCollection(_mockUserCollection.Object);
			_controller = new UserController(_userCollection, fixture.Mapper);
			_mapper = fixture.Mapper;
		}

		[Fact]
		public async Task CreateUser_CreatesUser()
		{
			// Arrange
			CreateUserModel user = new CreateUserModel { Subject = "Test Subject", Name = "Test User", Email = "test@example.com", Picture = "https://image.com" };
			_mockUserCollection.Setup(x => x.Create(It.IsAny<IUser>())).ReturnsAsync(_mapper.Map<UserModel>(user));

			// Act
			var result = await _controller.CreateUser(user);

			// Assert
			result.Result.Should().BeOfType<OkObjectResult>();
			var okResult = result.Result as OkObjectResult;
			var value = okResult.Value as UserModel;
			value.Subject.Should().Be("Test Subject");
			value.Name.Should().Be("Test User");
			value.Email.Should().Be("test@example.com");
		}

		[Fact]
		public async Task GetUserByToken_ReturnsUser()
		{
			// Arrange
			var user = new UserModel { Id = 1, Subject = "Test Subject", Name = "Test User", Email = "test@example.com", Picture = "https://image.com" };
			_mockUserCollection.Setup(x => x.ReadByToken(It.IsAny<string>())).ReturnsAsync(user);

			// Act
			var result = await _controller.GetUserByToken("testToken");

			// Assert
			result.Result.Should().BeOfType<OkObjectResult>();
			var okResult = result.Result as OkObjectResult;
			var value = okResult.Value as UserModel;
			value.Name.Should().Be("Test User");
			value.Email.Should().Be("test@example.com");
		}

		[Fact]
		public async Task UpdateUser_UpdatesUser()
		{
			// Arrange
			var user = new UserModel { Id = 1, Subject = "Test Subject", Name = "Test User", Email = "test@example.com" };
			_mockUserCollection.Setup(x => x.Update(It.IsAny<IUser>())).ReturnsAsync(user);

			// Act
			var result = await _controller.UpdateUser(user);

			// Assert
			result.Result.Should().BeOfType<OkObjectResult>();
			var okResult = result.Result as OkObjectResult;
			var value = okResult.Value as UserModel;
			value.Name.Should().Be("Test User");
			value.Email.Should().Be("test@example.com");
		}

		[Fact]
		public async Task DeleteUser_DeletesUser()
		{
			// Arrange
			var user = new UserModel { Id = 1, Subject = "Test Subject", Name = "Test User", Email = "test@example.com", Picture = "https://image.com" };
			_mockUserCollection.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

			// Act
			var result = await _controller.DeleteUser(1);

			// Assert
			result.Result.Should().BeOfType<OkObjectResult>();
			var okResult = result.Result as OkObjectResult;
			okResult.Value.Should().Be(true);
		}

		[Fact]
		public async Task AddSteamId_AddsSteamIdToUser()
		{
			// Arrange
			var user = new UserModel { Id = 1, Subject = "Test Subject", Name = "Test User", Email = "test@example.com", Picture = "https://image.com", SteamId = "testSteamId" };
			_mockUserCollection.Setup(x => x.AddSteamId(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

			// Act
			var result = await _controller.AddSteamId(1, "testSteamId");

			// Assert
			result.Result.Should().BeOfType<OkObjectResult>();
			var okResult = result.Result as OkObjectResult;
			okResult.Value.Should().Be(true);
		}
	}
}
