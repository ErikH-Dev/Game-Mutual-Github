using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{

		[HttpGet("user-information/{id}")]
		public ActionResult<string> GetUser(int id)
		{
			return Ok($"Get user {id}");
		}

		[HttpPost("sign-in/")]
		public ActionResult<string> CreateUser([Required]string subject, [Required]string nickname, [Url]string picture, [EmailAddress]string email)
		{
			return Ok("This is a return message for a test.");
		}

		[HttpPut("{id}")]
		[Authorize]
		public ActionResult<string> UpdateUser(int id)
		{
			return Ok($"Update user {id}");
		}

		[HttpDelete("{id}")]
		[Authorize]
		public ActionResult<string> DeleteUser(int id)
		{
			return Ok($"Delete user {id}");
		}
	}

}
