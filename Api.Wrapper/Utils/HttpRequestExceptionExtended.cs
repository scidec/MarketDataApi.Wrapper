using System.Net;

namespace MarketDataApi.Wrapper.Utils
{
    public class HttpRequestExceptionExtended : HttpRequestException
    {
        public HttpRequestExceptionExtended(string message, HttpStatusCode? statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode
        {
            get => _statusCode;
            set
            {
                _statusCode = value;
            }
        }

        private HttpStatusCode? _statusCode;
    }
}
