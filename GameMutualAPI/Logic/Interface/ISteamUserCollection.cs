using SharedObjects.SteamUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
	public interface ISteamUserCollection
	{
		Task<List<SteamUserModel>> GetUserByIDAsync(string steamUserId);
		Task<string> GetUserByCustomIDAsync(string steamUserCustomId);
	}
}
