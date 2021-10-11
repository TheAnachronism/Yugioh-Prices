using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace YugiohPrices.Library.Services
{
    public interface IYugiohPricesHttpClientService
    {
        /// <summary>
        /// Sends an http get request to the given url.
        /// </summary>
        Task<string> GetAsync(string url);

        Task<Image> GetImageAsync(string url);
    }

    internal class YugiohPricesHttpClientService : IYugiohPricesHttpClientService
    {
        private readonly HttpClient _httpClient;

        public YugiohPricesHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            var content = await response.Content.ReadAsStringAsync();
            var document = JsonDocument.Parse(content);
            return document.RootElement.ValueKind is JsonValueKind.Array
                ? document.RootElement.ToString()
                : document.RootElement.GetProperty("data").ToString();
        }

        public async Task<Image> GetImageAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            var content = await response.Content.ReadAsStreamAsync();
            return Image.FromStream(content);
        }
    }

    internal class HttpFailedRequestException : Exception
    {
        public HttpFailedRequestException(HttpStatusCode responseStatusCode, string responseReasonPhrase, string url)
        : this(GenerateGetException(responseStatusCode, responseReasonPhrase, url))
        {
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