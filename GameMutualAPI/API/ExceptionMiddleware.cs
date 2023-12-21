using API.ErrorSchemas;
using Exceptions;
using Exceptions.DbExceptions;
using System.Net;


namespace API
{
	public class ExceptionMiddleware
	{
		readonly RequestDelegate _next;
		readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext httpcontext)
		{
			try
			{
				await _next(httpcontext);
			}
			catch (GameMutualAPIException ex)
			{
				Error error = new() { Instance = httpcontext.Request.Path, Message = "", ErrorInstance = ex.GetType().Name[..^9] };
				switch (ex)
				{
					case DBException:
						error = HandleDBException((DBException)ex, httpcontext.Request.Path);
						break;
				}
				await HandleExceptionAsync(httpcontext, error.ToString(), error.StatusCode);
			}
			catch (Exception ex)
			{
				_logger.LogCritical(ex, "Unhandled Exceptioin");
				Error error = new() { StatusCode = HttpStatusCode.InternalServerError, Instance = httpcontext.Request.Path, Message = ex.Message, ErrorInstance = ex.GetType().Name[..^9] };
				await HandleExceptionAsync(httpcontext, error.ToString(), error.StatusCode);
			}
		}

		private static async Task HandleExceptionAsync(HttpContext context, string error, HttpStatusCode statusCode)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)statusCode;
			await context.Response.WriteAsync(error);
		}

		private Error HandleDBException(DBException ex, string requestPath)
		{
			_logger.LogError(ex, "Database Error");
			Error error = new() { Instance = requestPath, Message = "", ErrorInstance = ex.GetType().Name[..^9] };
			switch (ex)
			{
				case RequestTimeoutException:
					error.Message = "Service Unavailable, Please Try Again Later";
					error.StatusCode = HttpStatusCode.ServiceUnavailable;
					break;
				case ObjectAlreadyExsistsException:
					error.Message = "The Object Already Exists, Please Try Again";
					error.StatusCode = HttpStatusCode.Conflict;
					break;
				case ObjectNotFoundException:
					error.Message = "The Object Does Not Exist, Please Try Again";
					error.StatusCode = HttpStatusCode.NotFound;
					break;
				case ObjectReferenceException:
					error.Message = "The Object You Are Trying To Reference, Does Not Exist. Please Try Agian";
					error.StatusCode = HttpStatusCode.UnprocessableEntity;
					break;
				default:
					error.Message = "Internal Service Error";
					error.StatusCode = HttpStatusCode.InternalServerError;
					break;
			}
			return error;
		}
	}
}
