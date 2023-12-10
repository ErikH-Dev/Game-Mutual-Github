using Logic.Interface;
using Logic.Objects;
using Newtonsoft.Json;
using SharedObjects;
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
		public async Task<IEnumerable<ISteamUser>> GetUserByIDAsync(string steamUserId)
		{
			return await _iSteamUserCollection.GetUserByIDAsync(steamUserId);
		}
		public async Task<IEnumerable<ISteamUser>> GetUserByCustomIDAsync(string steamUserId)
		{
			string steam64ID = await _iSteamUserCollection.GetUserByCustomIDAsync(steamUserId);
			return await _iSteamUserCollection.GetUserByIDAsync(steam64ID);
		}
	}
}
