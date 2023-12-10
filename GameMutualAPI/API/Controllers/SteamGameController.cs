using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic;
using Logic.Interface;
using DAL.SteamGameModels;
using SharedObjects;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SteamGameController : ControllerBase
	{
		private readonly SteamGameCacheHandler _steamGameCacheHandler;
		private readonly ILogger<SteamGameController> _logger;

		private readonly int GAMES_PER_PAGE = 100;

		public SteamGameController(SteamGameCacheHandler steamGameCacheHandler, ILogger<SteamGameController> logger)
		{
			_steamGameCacheHandler = steamGameCacheHandler;
			_logger = logger;
		}

		[HttpGet("GetByID/{steamUserID}")]
		public async Task<IEnumerable<ISteamGame>> GetGamesOfUser(int? pageNumber, string steamUserID = "76561198274926223")
		{
			IEnumerable<ISteamGame> steamGames = await _steamGameCacheHandler.GetGamesOfUser(steamUserID);
			return GetPagedResults(steamGames, pageNumber);
		}

		[HttpGet("GetByID/search/{steamuserID}/")]
		public async Task<IEnumerable<ISteamGame>> SearchGamesOfUser(string query, int? pageNumber, string steamUserID = "76561198274926223")
		{
			IEnumerable<ISteamGame> steamGames = await _steamGameCacheHandler.GetGamesOfUser(steamUserID);
			string lowerQuery = query.ToLower();
			steamGames = steamGames.Where(x => x.Name.ToLower().Contains(lowerQuery)).ToList();
			return GetPagedResults(steamGames, pageNumber);
		}

		[HttpGet("GetMutuallyOwnedGames/{*steamUserIDs}", Name = "GetMutuallyOwnedGames")]
		public async Task<IEnumerable<ISteamGame>> GetMutuallyOwnedGames(int? pageNumber, string steamUserIDs)
		{
			List<string> userIDs = steamUserIDs.Split(',').ToList();
			IEnumerable<ISteamGame> steamGames = await _steamGameCacheHandler.GetMutualGames(userIDs);
			return GetPagedResults(steamGames, pageNumber);
		}

		[HttpGet("GetMutuallyOwnedGames/search/{*steamUserIDs}", Name = "SearchMutuallyOwnedGames")]
		public async Task<IEnumerable<ISteamGame>> SearchMutuallyOwnedGames(string query, int? pageNumber, string steamUserIDs)
		{
			List<string> userIDs = steamUserIDs.Split(',').ToList();
			IEnumerable<ISteamGame> steamGames = await _steamGameCacheHandler.GetMutualGames(userIDs);
			string lowerQuery = query.ToLower();
			steamGames = steamGames.Where(x => x.Name.ToLower().Contains(lowerQuery)).ToList();
			return GetPagedResults(steamGames, pageNumber);
		}

		private IEnumerable<ISteamGame> GetPagedResults(IEnumerable<ISteamGame> steamGames, int? pageNumber)
		{
			int totalGames = steamGames.ToList().Count;
			int startIndex = ((pageNumber ?? 0) - 1) * GAMES_PER_PAGE;
			if (startIndex < totalGames)
			{
				int gamesToTake = Math.Min(GAMES_PER_PAGE, totalGames - startIndex);

				return steamGames.Skip(startIndex).Take(gamesToTake).ToList();
			}

			return new List<ISteamGame>();
		}
	}
}
