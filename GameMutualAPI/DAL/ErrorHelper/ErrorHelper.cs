using Exceptions;
using Exceptions.DbExceptions;
using MySql.Data.MySqlClient;

namespace DAL.ErrorHelper
{
	public class ErrorHelper : IErrorHelper
	{
		public void HandleError(Exception ex)
		{
			if (ex.InnerException != null && ex.InnerException.GetType() == typeof(MySqlException))
			{
				MySqlException exception = (MySqlException)ex.InnerException;
				switch (exception.Number)
				{
					case 1042:
					case 1045:
						throw new RequestTimeoutException("Connection to database timed-out", ex);
					case 1062:
						throw new ObjectAlreadyExsistsException("Object already exists", ex);
					case 1452:
						throw new ObjectReferenceException("The objectreference doens't exist", ex);
					default:
						throw new DBException("There was an error quering the database", ex);
				}
			}
			throw new DBException("Something went wrong, see exception", ex);
		}
	}
}
