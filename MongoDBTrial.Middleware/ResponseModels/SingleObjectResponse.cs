namespace MongoDBTrial.Middleware.ResponseModels
{
    /// <summary>
    /// Response model for requests that return a single object.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SingleObjectResponse<TModel> : BaseResponse
    {
        /// <value> Result object. </value>
        public TModel Result { get; set; }
    }
}
