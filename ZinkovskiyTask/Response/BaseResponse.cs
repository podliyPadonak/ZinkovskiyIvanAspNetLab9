using Microsoft.AspNetCore.Mvc;

namespace ZinkovskiyTask.Response
{
    public class BaseResponse
    {
        public string Description;
        public StatusCodeResult StatusCode;
        public object Data;
        public BaseResponse() { }
        public BaseResponse(object data, int statusCode, string description = "")
        {
            Description = description;
            StatusCode = new StatusCodeResult(statusCode);
            Data = data;
        }
    }
}