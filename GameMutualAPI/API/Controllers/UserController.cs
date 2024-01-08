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
		public async Task<ActionResult<IUser>> UpdateUser(UserModel user)
		{
			var returnUser = await _userCollection.Update(user);
			return Ok(returnUser);
		}

		[HttpDelete]
		[Route("Delete")]
		[Authorize]
		public async Task<ActionResult<bool>> DeleteUser(int id)
		{
			return Ok(await _userCollection.Delete(id));
		}
		[HttpPost]
		[Route("AddSteamId")]
		[Authorize]
		public async Task<ActionResult<bool>> AddSteamId(int userId, string steamId)
		{
			return Ok(await _userCollection.AddSteamId(userId, steamId));
		}
	}

}
