using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class UnableToUpdateObjectException : DBException
	{
		public UnableToUpdateObjectException()
		{
		}

		public UnableToUpdateObjectException(string? message) : base(message)
		{
		}

		public UnableToUpdateObjectException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
		protected UnableToUpdateObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
