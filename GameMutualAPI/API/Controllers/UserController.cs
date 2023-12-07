using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	// Create a new controller called UserController that has endpoints for crud operations on users
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		// Create a new endpoint that returns a list of users
		[HttpGet]
		public ActionResult<string> GetUsers()
		{
			return Ok("Get users");
		}

		// Create a new endpoint that returns a single user
		[HttpGet("{id}")]
		public ActionResult<string> GetUser(int id)
		{
			return Ok($"Get user {id}");
		}

		// Create a new endpoint that creates a user
		[HttpPost]
		public ActionResult<string> CreateUser()
		{
			return Ok("Create user");
		}

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
		public ActionResult<string> DeleteUser(int id)
		{
			return Ok($"Delete user {id}");
		}
	}

}
