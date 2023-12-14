using SharedObjects;

namespace Logic.Interface
{
	public interface IUserCollection
	{
		Task<IUser> GetUser(string token);
	}
}