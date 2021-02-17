using Microsoft.AspNetCore.Http;
using MongoDBTrial.Middleware.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MongoDBTrial.Middleware
{
    /// <summary>
    /// Catches errors occurring elsewhere in the project.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor of <c>ExceptionMiddleware</c> class.
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the method or constructor reflected by this MethodInfo instance.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string message = "Wrong url bro !";
            try
            {
                await _next.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            if (!context.Response.HasStarted)
            {
                var response = new ExceptionResponseModel(message);
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Success = false;
                var json = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
