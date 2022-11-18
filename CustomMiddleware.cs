using Core.Services;
using Microsoft.Extensions.Options;
using System.Runtime.Serialization;

namespace Core
{
	public class CustomMiddleware
	{
		private RequestDelegate _next;

		public CustomMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IResponseFormatter formatter1, IResponseFormatter formatter2, IResponseFormatter formatter3)
		{
			if (context.Request.Path == "/middleware")
			{
				await formatter1.Format(context, String.Empty);
				await formatter2.Format(context, String.Empty);
				await formatter3.Format(context, String.Empty);
			}
			if (_next != null)
			{
				await _next(context);
			}
		}
	}
}
