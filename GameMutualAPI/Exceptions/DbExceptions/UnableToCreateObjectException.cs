using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class UnableToCreateObjectException : Exception
	{
		public UnableToCreateObjectException()
		{
		}

		public UnableToCreateObjectException(string? message) : base(message)
		{
		}

		public UnableToCreateObjectException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected UnableToCreateObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}