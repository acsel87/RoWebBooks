using Microsoft.AspNetCore.Mvc;

namespace RWBooks.App.Models
{
    public class ApiError : ObjectResult
    {
        public int ResponseStatusCode { get; }
        public bool IsSuccess { get; }
        public string Message { get; }

        public ApiError(
            int responseStatusCode = StatusCodes.Status400BadRequest, 
            bool isSuccess = false, 
            string message = "A problem happened while handling your request.")
            : base(new { isSuccess, responseStatusCode, message })
        {
            StatusCode = responseStatusCode;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
