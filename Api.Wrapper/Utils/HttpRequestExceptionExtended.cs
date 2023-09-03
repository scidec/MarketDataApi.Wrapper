using System.Net;

namespace MarketDataApi.Wrapper.Utils
{
    public class HttpRequestExceptionExtended : HttpRequestException
    {
        public HttpRequestExceptionExtended(string message, HttpStatusCode? statusCode, LogInformation? log) : base(message)
        {
            this.StatusCode = statusCode;
            this.Log = log;
        }

        public new HttpStatusCode? StatusCode
        {
            get => _statusCode;
            set
            {
                _statusCode = value;
            }
        }

        public LogInformation? Log { get; set; }

        private HttpStatusCode? _statusCode;
    }

    public class LogInformation
    {
        public string Request { get; set; }
        public string Response { get; set; }
        public string CfRayHeader { get; set; }
    }
}
