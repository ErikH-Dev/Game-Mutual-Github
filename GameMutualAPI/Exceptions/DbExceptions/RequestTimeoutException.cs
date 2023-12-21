using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class RequestTimeoutException : DBException
	{
		public RequestTimeoutException()
		{
		}

		public RequestTimeoutException(string? message) : base(message)
		{
		}

		public RequestTimeoutException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected RequestTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}