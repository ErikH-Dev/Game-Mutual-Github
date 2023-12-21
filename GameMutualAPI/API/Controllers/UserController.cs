using API.Models.Create;
using API.Models.General;
using AutoMapper;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserCollection _userCollection;
		private readonly IMapper _mapper;
		public UserController(UserCollection userCollection, IMapper mapper)
		{
			_userCollection = userCollection;
			_mapper = mapper;
		}
		[HttpPost]
		[Route("Create")]
		public async Task<ActionResult<IUser>> CreateUser(CreateUserModel user)
		{
			IUser mappedUser = _mapper.Map<UserModel>(user);
			var result = await _userCollection.Create(mappedUser);
			return Ok(result);
		}
		[HttpGet]
		[Route("ReadByToken")]
		[Authorize]
		public async Task<ActionResult<IUser>> GetUserByToken(string token)
		{
			var user = await _userCollection.ReadByToken(token);
			return Ok(user);
		}

		[HttpPut]
		[Route("Update")]
		[Authorize]
		public async Task<ActionResult<string>> UpdateUser(UserModel user)
		{
			await _userCollection.Update(user);
			return Ok($"Update user {user.Name}");
		}

		[HttpDelete]
		[Route("Delete")]
		[Authorize]
		public async Task<ActionResult<string>> DeleteUser(int id)
		{
			await _userCollection.Delete(id);
			return Ok($"Delete user {id}");
		}
		[HttpPost]
		[Route("AddSteamId")]
		[Authorize]
		public async Task<ActionResult<string>> AddSteamId(int userId, string steamId)
		{
			await _userCollection.AddSteamId(userId, steamId);
			return Ok($"Add steamId {steamId} to user {userId}");
		}
	}

}
