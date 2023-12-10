using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Objects
{
	internal class SteamUser : ISteamUser
	{
		public string SteamID { get; set; }
		public string PersonaName { get; set; }
		public string ProfileURL { get; set; }
		public string AvatarFull { get; set; }
	}
}
