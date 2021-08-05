using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YugiohPrices.Library.Client;
using YugiohPrices.Library.Services;

namespace YugiohPrices.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection().AddYugiohPricesClient().BuildServiceProvider();
            var client = services.GetRequiredService<IYugiohPricesClient>();

            var result = await client.GetCardPricesForPrintTag("SDRR-EN044");
        }
    }
}