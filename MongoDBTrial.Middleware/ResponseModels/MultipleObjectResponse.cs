using System.Collections.Generic;

namespace MongoDBTrial.Middleware.ResponseModels
{
    /// <summary>
    /// Response model for requests that return a multiple object(List).
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class MultipleObjectResponse<TModel> : BaseResponse
    {
        /// <value> Result list. </value>
        public IEnumerable<TModel> Result { get; set; }
    }
}
