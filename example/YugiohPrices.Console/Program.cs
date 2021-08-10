using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YugiohPrices.Library.Client;
using YugiohPrices.Library.Services;
using YugiohPrices.Models;

namespace YugiohPrices.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection().AddYugiohPricesClient().BuildServiceProvider();
            var client = services.GetRequiredService<IYugiohPricesClient>();

            var result = await client.GetTop100Cards(CardRarity.UltraRare);
            System.Console.WriteLine(result.Count());
        }
    }
}