using API.ValidationAttributes;
using Logic;
using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.SteamUserModels;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SteamUserController : ControllerBase
	{
		private readonly SteamUserCollection _steamUserCollection;
		private readonly ILogger<SteamUserController> _logger;
		public SteamUserController(ISteamUserCollection iSteamUserCollection, ILogger<SteamUserController> logger)
		{
			_steamUserCollection = new(iSteamUserCollection);
			_logger = logger;
		}
		[HttpGet("GetByID/{steamUserID}")]
		public async Task<List<SteamUserModel>> GetSteamUserDataByID([ValidSteam64ID] string steamUserID)
		{
			return await _steamUserCollection.GetUserByIDAsync(steamUserID);
		}
		[HttpGet("GetByCustomID/{steamUserCustomID}")]
		public async Task<List<SteamUserModel>> GetSteamUserByCustomID ([ValidSteamVanityURL] string steamUserCustomID)
		{
			return await _steamUserCollection.GetUserByCustomIDAsync(steamUserCustomID);
		}
	}
}
