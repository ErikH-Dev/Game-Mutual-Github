﻿using Logic;
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
		public UserController(UserCollection userCollection)
		{
			_userCollection = userCollection;
		}
		[HttpGet]
		// Create a new endpoint that updates a user
		[HttpPut("{id}")]
		[Authorize]
		public ActionResult<string> UpdateUser(int id)
		{
			return Ok($"Update user {id}");
		}

		// Create a new endpoint that deletes a user
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<ActionResult<IUser>> GetUser(string token)
		{
			var user = await _userCollection.GetUser(token);
			return Ok(user);
		}
	}

}
