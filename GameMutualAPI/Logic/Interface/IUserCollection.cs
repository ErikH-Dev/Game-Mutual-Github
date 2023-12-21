using SharedObjects;

namespace Logic.Interface
{
	public interface IUserCollection
	{
		Task<IUser> Create(IUser user);
		Task<IUser> Read(int id);
		Task<IUser> ReadByToken(string subjectToken);
		Task<IUser> Update(IUser user);
		Task<bool> Delete(int id);
		Task<bool> AddSteamId(int userId, string steamId);
	}
}