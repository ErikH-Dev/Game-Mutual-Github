using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects
{
	public interface ISteamGame
	{
		public int AppID { get; set; }
		public string Name { get; set; }
	}
}
