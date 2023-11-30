using Logic.Interface;
using Newtonsoft.Json;
using SharedObjects.SteamUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class SteamUserCollection
	{
		private readonly ISteamUserCollection _iSteamUserCollection;
		public SteamUserCollection(ISteamUserCollection iSteamUserCollection)
		{
			_iSteamUserCollection = iSteamUserCollection;
		}
		public async Task<List<SteamUserModel>> GetUserAsync(string steamUserId)
		{
			return await _iSteamUserCollection.GetUserAsync(steamUserId);
		}
	}
}
