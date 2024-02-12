using Microsoft.AspNetCore.Mvc;

namespace ZinkovskiyTask.Response
{
    public class BaseResponse<T>
    {
        public string Description;
        public int StatusCode;
        public T Data;
        public BaseResponse() { }
        public BaseResponse(T data, int statusCode, string description = "")
        {
            Description = description;
            StatusCode = statusCode;
            Data = data;
        }
    }
}