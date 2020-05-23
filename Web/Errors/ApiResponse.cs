using Core.Constants;

namespace Web.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {

            return statusCode switch
            {
                AppConstants.BadRequest400 => "A bad request, you have made",
                AppConstants.Unauthorized401 => "Authorized, you are not",
                AppConstants.NotFound404 => "Resource found, it was not",
                AppConstants.ServerError500 => "Errors are the path to the dark side. Errors lead to anger.  Anger leads to hate.  Hate leads to career change",
                _ => null
            };
        }
    }
}