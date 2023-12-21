using Logic.Interface;
using SharedObjects;

namespace Logic
{
	public class UserCollection
	{
		private readonly IUserCollection _iUserCollection;
		public UserCollection(IUserCollection iUserCollection)
		{
			_iUserCollection = iUserCollection;
		}
		public async Task<IUser> Create(IUser user)
		{
			return await _iUserCollection.Create(user);
		}

		public async Task<IUser> Read(int id)
		{
			return await _iUserCollection.Read(id);
		}

		public async Task<IUser> ReadByToken(string subjectToken)
		{
			return await _iUserCollection.ReadByToken(subjectToken);
		}

		public async Task<IUser> Update(IUser user)
		{
			return await _iUserCollection.Update(user);
		}

		public async Task<bool> Delete(int id)
		{
			return await _iUserCollection.Delete(id);
		}
		public async Task<bool> AddSteamId(int userId, string steamId)
		{
			return await _iUserCollection.AddSteamId(userId, steamId);
		}
	}
}