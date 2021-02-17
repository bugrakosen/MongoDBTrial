namespace MongoDBTrial.Middleware.ResponseModels
{
    /// <summary>
    /// Model of Exception.
    /// </summary>
    public class ExceptionResponseModel : BaseResponse
    {

        /// <summary>
        /// Constructor of <c>ExceptionModel</c> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public ExceptionResponseModel(string message, int statusCode = 500)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
