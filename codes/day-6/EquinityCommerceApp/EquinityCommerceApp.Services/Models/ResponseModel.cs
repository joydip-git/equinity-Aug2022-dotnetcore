using System.Net;

namespace EquinityCommerceApp.Services.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }
    }
}
