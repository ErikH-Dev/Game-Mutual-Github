using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class ObjectAlreadyExsistsException : DBException
	{
		public ObjectAlreadyExsistsException()
		{
		}

		public ObjectAlreadyExsistsException(string? message) : base(message)
		{
		}

		public ObjectAlreadyExsistsException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ObjectAlreadyExsistsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}