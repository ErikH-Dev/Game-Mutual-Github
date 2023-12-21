using API.ValidationAttributes;
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
		public SteamUserController(ISteamUserCollection iSteamUserCollection)
		{
			_steamUserCollection = new(iSteamUserCollection);
		}
		[HttpGet("GetByID/{steamUserID}")]
		public async Task<IEnumerable<ISteamUser>> GetSteamUserDataByID([ValidSteam64ID] string steamUserID)
		{
			return await _steamUserCollection.GetUserByIDAsync(steamUserID);
		}
		[HttpGet("GetByCustomID/{steamUserCustomID}")]
		public async Task<IEnumerable<ISteamUser>> GetSteamUserByCustomID([ValidSteamVanityURL] string steamUserCustomID)
		{
			return await _steamUserCollection.GetUserByCustomIDAsync(steamUserCustomID);
		}
	}
}
