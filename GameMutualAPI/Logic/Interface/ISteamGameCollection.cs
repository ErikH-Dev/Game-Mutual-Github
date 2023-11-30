using SharedObjects.SteamGameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
	public interface ISteamGameCollection
	{
		Task<List<SteamGameModel>> GetGamesOfUserAsync(string steamUserId);
	}
}
