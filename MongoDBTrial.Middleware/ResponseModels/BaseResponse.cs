using Microsoft.AspNetCore.Http;

namespace MongoDBTrial.Middleware.ResponseModels
{
    /// <summary>
    /// Base response model for API responses.
    /// </summary>
    public abstract class BaseResponse
    {
        /// <value> 
        /// Information of whether the request was successful. 
        /// Default: true. 
        /// If request is success: Success = true. 
        /// If request is fail: Success = false. 
        /// </value>
        public bool Success { get; set; } = true;

        /// <value> 
        /// Message of response. 
        /// Default: İşlem başarılı!!
        /// </value>
        public string Message { get; set; } = "İşlem Başarılı!!";

        /// <value> 
        /// Http status code of response. 
        /// Default: 200OK
        /// </value>
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

    }
}
