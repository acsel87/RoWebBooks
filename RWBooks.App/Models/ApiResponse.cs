using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace RWBooks.App.Models
{
    public class ApiResponse<T> : ObjectResult
    {
        public bool IsSuccess { get; }
        public T? Data { get; }
        public int ResponseStatusCode { get; }
        public string Message { get; }        

        public ApiResponse(T data, bool isSuccess = true, int responseStatusCode = StatusCodes.Status200OK, string message = "Success")
            : base(new { data, isSuccess, responseStatusCode, message })
        {
            IsSuccess = isSuccess;
            Data = data;
            StatusCode = responseStatusCode;
            Message = message;
        }
    }   
}
