namespace API.Errors
{
    public class ApiErrorResponse
    {
        private string GetDefaultMessageForStatusCode(int statusCode) {

            return statusCode switch { 
                400=> "A Bad Request",
                401=> "Unauthorised",
                404=> "Resource Not Found",
                500=>"Internal Server Error",
                _=>null
            };
        }
        public ApiErrorResponse(int statusCode, string message=null) { 
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }    
    }
}
