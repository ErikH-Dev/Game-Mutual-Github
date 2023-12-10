using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Objects
{
	internal class SteamGame : ISteamGame
	{
		public int AppID { get ; set ; }
		public string Name { get ; set ; }
	}
}
