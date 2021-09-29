using Microsoft.Extensions.DependencyInjection;
using YugiohPrices.Library.Services;

namespace YugiohPrices.LibraryTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddYugiohPricesClient();
        }
    }
}