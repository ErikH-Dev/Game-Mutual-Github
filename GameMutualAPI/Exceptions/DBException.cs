using System.Runtime.Serialization;

namespace Exceptions
{
	[Serializable]
	public class DBException : GameMutualAPIException
	{
		public DBException()
		{
		}

		public DBException(string? message) : base(message)
		{
		}

		public DBException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected DBException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}