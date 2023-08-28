using MarketDataApi.Wrapper.Utils;
using Newtonsoft.Json;
using System.Net;

namespace MarketDataApi.Wrapper.Interfaces
{
    internal abstract class BaseAPI : IDisposable
    {
        private readonly string _apiToken;
        private readonly HttpClient _httpClient;

        public BaseAPI(string apiToken, IWebProxy proxy = null, string source = null)
        {
            _apiToken = apiToken;

            if (proxy != null)
            {
                HttpClientHandler myHandler = new()
                {
                    Proxy = proxy
                };

                _httpClient = new HttpClient(myHandler);
            }
            else
            {
                _httpClient = new HttpClient();
            }

            if (String.IsNullOrEmpty(source))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "marketdataapi.wrapper");
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", source);
            }

            if (!string.IsNullOrEmpty(_apiToken))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "token " + _apiToken);
            }
        }

        public async Task<T> ExecuteQueryAsync<T>(string uri)
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = new HttpMethod("GET");

                request.RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute);

                foreach (var header in _httpClient.DefaultRequestHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    string rayId = "Not available";
                    if (response.Headers.TryGetValues("Xcf-ray", out IEnumerable<string> values))
                    {
                        rayId = values.First();
                    }

                    var logData = new LogInformation
                    {
                        Request = request.Method.ToString().ToUpper() + " " + request.RequestUri.ToString(),
                        Response = await response.Content.ReadAsStringAsync(),
                        CfRayHeader = rayId,
                    };

                    throw new HttpRequestExceptionExtended($"There was an error while executing the HTTP query. Reason: {response.ReasonPhrase}", response.StatusCode, logData);
                }

                string content = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(content);
                if (result == null) throw new NullReferenceException();
                return result;
            }
        }

        public async Task<string> ExecuteQueryAsync(string uri)
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = new HttpMethod("GET");

                request.RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute);

                foreach (var header in _httpClient.DefaultRequestHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    string rayId = "Not available";
                    if (response.Headers.TryGetValues("Xcf-ray", out IEnumerable<string> values))
                    {
                        rayId = values.First();
                    }

                    var logData = new LogInformation
                    {
                        Request = request.Method.ToString().ToUpper() + " " + request.RequestUri.ToString(),
                        Response = await response.Content.ReadAsStringAsync(),
                        CfRayHeader = rayId,
                    };

                    throw new HttpRequestExceptionExtended($"There was an error while executing the HTTP query. Reason: {response.ReasonPhrase}", response.StatusCode, logData);
                }

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        public string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is Enum)
            {
                var name = Enum.GetName(value.GetType(), value);
                return name.ToLower();
            }
            else if (value is bool)
            {
                return Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is DateTime)
            {
                //ISO 8601
                return ((DateTime)value).ToString("yyyy-MM-dd", cultureInfo);
            }
            else if (value is DateTimeOffset)
            {
                //ISO 8601
                return ((DateTimeOffset)value).ToString("yyyy-MM-dd", cultureInfo);
            }
            else if (value is byte[])
            {
                return Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = Enumerable.OfType<object>((Array)value);
                return string.Join(",", Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
