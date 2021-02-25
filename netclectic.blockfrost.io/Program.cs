using Microsoft.Extensions.Configuration;
using netclectic.blockfrost.api;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace netclectic.blockfrost.io
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static async Task Main(string[] args)
        {
            // dotnet user-secrets init
            // dotnet user-secrets set "BlockFrost:ApiKey" "blah"

            string env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            bool isDevelopment = string.IsNullOrEmpty(env) || string.Equals(env, "development", StringComparison.OrdinalIgnoreCase);
            var builder = new ConfigurationBuilder();
            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }
            IConfigurationRoot config = builder.Build();
            IConfigurationProvider secretProvider = config.Providers.First();
            if (!secretProvider.TryGet("BlockFrost:ApiKey", out string apiKey)) return;

            Console.WriteLine($" - apiKey: {apiKey}");

            const string apiTestNetUrl = "https://cardano-testnet.blockfrost.io/api/v0";
            const string apiMainNetUrl = "https://cardano-mainnet.blockfrost.io/api/v0";

            while (true)
            {
                Console.WriteLine("1. Test Net");
                Console.WriteLine("2. Main Net");
                Console.WriteLine("Q. Quit");
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.Q)
                    break;

                string apiUrl = (choice.Key == ConsoleKey.D2) ? apiMainNetUrl : apiTestNetUrl;
                Console.WriteLine($" - apiUrl: {apiUrl}");

                var blockFrost = new BlockFrostApi(apiUrl, apiKey);

                /*
                var info = await blockFrost.Api.GetApiInfo();
                Console.WriteLine($"{info}");

                var health = await blockFrost.Api.GetApiHealth();
                Console.WriteLine($"{health}");

                var clock = await blockFrost.Api.GetApiClock();
                Console.WriteLine($"{clock} - {clock.ToUtcDateTime()}");
                */

                BlockContent block = await blockFrost.Api.GetLatestBlock();
                Console.WriteLine($"{block}");

                Console.Write("Enter block hash: ");
                string blockHash = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(blockHash))
                {
                    block = await blockFrost.Api.GetBlock(blockHash);
                    Console.WriteLine($"{block}");
                }

                Console.WriteLine("Prevs...\n");
                foreach (BlockContent b in await blockFrost.Api.GetPrevBlocks(blockHash))
                {
                    Console.WriteLine($"{b}");
                }

                Console.Write("Enter block hash: ");
                blockHash = Console.ReadLine();

                Console.WriteLine("Nexts...\n");
                foreach (BlockContent b in await blockFrost.Api.GetNextBlocks(blockHash))
                {
                    Console.WriteLine($"{b}");
                }

                Console.WriteLine("\nPress a key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
