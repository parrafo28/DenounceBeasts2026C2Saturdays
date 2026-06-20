namespace DenounceBeasts.API.Models.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        //public string Message { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Data = data,
                StatusCode = statusCode
            };
        }
        //public static ApiResponse<T> SuccessResponse(T data, string message, int statusCode = 200)
        //{
        //    return new ApiResponse<T>
        //    {
        //        IsSuccess = true,
        //        Data = data,
        //        StatusCode = statusCode                ,
        //        ErrorMessage = message
        //    };
        //}

        public static ApiResponse<T> FailureResponse(string errorMessage, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode
            };
        }

    }
}
