using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
	public class DBConn
	{
		public MySqlConnection conn;
		public DBConn(string connString)
		{
			conn = new MySqlConnection(connString);
		}
	}
}
