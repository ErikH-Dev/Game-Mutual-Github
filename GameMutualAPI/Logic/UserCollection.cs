using Logic.Interface;
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
		private readonly IUserCollection _iUserCollection;
		public async Task<IUser> GetUser(string token)
		{
			return await _iUserCollection.GetUser(token);
		}
	}
}
