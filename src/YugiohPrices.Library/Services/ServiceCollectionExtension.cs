using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using YugiohPrices.Library.Client;

namespace YugiohPrices.Library.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddYugiohPricesClient(this IServiceCollection services)
        {
            services.Configure<YugiohPricesClientJsonSerializerOptions>(x =>
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };

                x.JsonSerializerOptions = options;
            });
            services.AddTransient<IYugiohPricesClient, YugiohPricesClient>();
            services.AddHttpClient<IHttpClientService, HttpClientService>();

            return services;
        }
    }
}