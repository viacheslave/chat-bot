using Bot.Telegram.Core;
using Bot.Telegram.Core.Strategies;
using System.Threading.Tasks;

namespace Bot.Console
{
	static class Program
	{
		static void Main(string[] args)
		{
			MainAsync().GetAwaiter().GetResult();
		}

		static async Task MainAsync()
		{
			var bot = TelegramBot.Create();

			bot.AddModule<WeatherStrategy>();
			
			await bot.StartSafePollingAsync();
		}
	}
}
