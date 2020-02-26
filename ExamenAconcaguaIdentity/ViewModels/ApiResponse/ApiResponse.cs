using Microsoft.AspNetCore.Mvc;

namespace ExamenAconcaguaIdentity.ViewModels.ApiResponse
{

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public static ApiResponse Error(string errorMessage)
        {
            return new ApiResponse
            {
                ErrorMessage = errorMessage
            };
        }

        public static ApiResponse Ok()
        {
            return new ApiResponse { Success = true };
        }

    }

    public class ApiResponse<T> : ApiResponse
    {
        
        public T Object { get; set; }
        
        public static ApiResponse<T> Ok(T t)
        {
            return new ApiResponse<T> 
            {
                Success = true, Object = t 
            };
        }        
    }
}
