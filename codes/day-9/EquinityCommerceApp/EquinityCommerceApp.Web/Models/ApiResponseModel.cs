using System.Net;

namespace EquinityCommerceApp.Web.Models
{
    public class ApiResponseModel<T>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public T Record { get; set; }
    }
}
