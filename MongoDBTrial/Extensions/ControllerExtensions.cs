using Microsoft.AspNetCore.Http;
using MongoDBTrial.Middleware.ResponseModels;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MongoDBTrial.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<MultipleObjectResponse<TModel>> GetArrayResponseForGetAllAsync<TModel>(this List<TModel> modelList, string messageContent)
        {
            MultipleObjectResponse<TModel> response = new MultipleObjectResponse<TModel>();
            response.StatusCode = StatusCodes.Status200OK;
            if (modelList.IsNullOrEmpty())
            {
                response.Message = messageContent;
                response.StatusCode = StatusCodes.Status204NoContent;
                response.Success = true;
            }

            response.Result = modelList;

            return response;
        }

        public static async Task<SingleObjectResponse<TModel>> GetSingleObjectResponseForGetByIdAsync<TModel>(this TModel model, string messageContent)
        {
            SingleObjectResponse<TModel> response = new SingleObjectResponse<TModel> { StatusCode = StatusCodes.Status200OK, Success = true };

            if (model == null)
            {
                response.Message = $"İstenilen {messageContent} bulunamadı. Veritabanında bulunmayan veya silinmiş bir veriye erişmeye çalıştınız!";
                response.StatusCode = StatusCodes.Status204NoContent;
            }

            response.Result = model;
            return response;
        }


        public static async Task<MultipleObjectResponse<TModel>> GetArrayResponseForDeleteAsync<TModel>(this ConfiguredTaskAwaitable asyncTask, IEnumerable<TModel> modelList, string messageContent)
        {
            MultipleObjectResponse<TModel> response = new MultipleObjectResponse<TModel>();
            if (modelList.IsNullOrEmpty())
            {
                response.Message = "Silinecek veri yok.";
                response.StatusCode = StatusCodes.Status204NoContent;
                response.Success = true;
            }
            else
            {
                await asyncTask;
                response.Message = $"{messageContent} başarıyla silindi.";
                response.StatusCode = StatusCodes.Status200OK;
                response.Success = true;
            }

            return response;
        }

        public static async Task<SingleObjectResponse<TModel>> GetSingleObjectResponseForAddOrUpdateAsync<TModel>(this ConfiguredTaskAwaitable asyncTask, string messageContent)
        {
            SingleObjectResponse<TModel> response = new SingleObjectResponse<TModel>();

            await asyncTask;

            response.Message = messageContent;

            return response;
        }


        /// <summary>
        /// Checks whether or not collection is null or empty. Assumes collection can be safely enumerated multiple times.
        /// </summary>
        public static bool IsNullOrEmpty(this IEnumerable @this) => @this == null || @this.GetEnumerator().MoveNext() == false;
    }
}
