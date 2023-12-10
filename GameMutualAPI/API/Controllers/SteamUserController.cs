using API.ValidationAttributes;
using DAL.SteamUserModels;
using Logic;
using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using SharedObjects;

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
		public async Task<IEnumerable<ISteamUser>> GetSteamUserDataByID([ValidSteam64ID] string steamUserID)
		{
			return await _steamUserCollection.GetUserByIDAsync(steamUserID);
		}
		[HttpGet("GetByCustomID/{steamUserCustomID}")]
		public async Task<IEnumerable<ISteamUser>> GetSteamUserByCustomID ([ValidSteamVanityURL] string steamUserCustomID)
		{
			return await _steamUserCollection.GetUserByCustomIDAsync(steamUserCustomID);
		}
	}
}
