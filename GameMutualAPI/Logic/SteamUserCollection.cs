using Logic.Interface;
using SharedObjects;

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
