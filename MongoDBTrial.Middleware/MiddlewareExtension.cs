using Microsoft.AspNetCore.Builder;

namespace MongoDBTrial.Middleware
{
    /// <summary>
    /// With the extension method, we ensure that our custom method is added under IApplicationBuilder.
    /// </summary>
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Extension method of <c>ExceptionMiddleware</c> class.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
