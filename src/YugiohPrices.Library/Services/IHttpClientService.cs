using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace YugiohPrices.Library.Services
{
    public interface IHttpClientService
    {
        /// <summary>
        /// Sends an http get request to the given url.
        /// </summary>
        Task<string> GetAsync(string url);
    }

    internal class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            var content = await response.Content.ReadAsStreamAsync();
            var document = JsonDocument.Parse(content);
            return document.RootElement.GetProperty("data").ToString();
        }
    }

    internal class HttpFailedRequestException : Exception
    {
        public HttpFailedRequestException(HttpStatusCode responseStatusCode, string responseReasonPhrase, string url)
        : this(GenerateGetException(responseStatusCode, responseReasonPhrase, url))
        {
            throw new NotImplementedException();
        }

        private static string GenerateGetException(HttpStatusCode responseStatusCode, string responseReasonPhrase, string url)
        {
            return $"Status Code: {(int)responseStatusCode} - Reasoning Phrase: {responseReasonPhrase} : url: {url}";
        }

        private HttpFailedRequestException(string message) : base(message)
        {
        }
    }
}