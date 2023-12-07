using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class UserCollection
	{
		public List<User> GetUsers()
		{
			return new List<User>();
		}

		public User GetUser(int id)
		{
			return new User();
		}

		public User CreateUser()
		{
			return new User();
		}

		public User UpdateUser(int id)
		{
			return new User();
		}

		public User DeleteUser(int id)
		{
			return new User();
		}
	}
}
