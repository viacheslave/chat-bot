using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Entities;
using Bot.Telegram.CoreAbstraction;
using System.Linq;
using Bot.Telegram.Core.Models;
using Bot.Common.Serialization;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Bot.Telegram.Modules;

namespace Bot.Telegram.Core.Strategies
{
	public class WeatherStrategy : IMessageProcessingStrategy
	{
		private readonly string[] _triggerWords = { "!погода", "/погода", "!weather", "/weather" };
		private readonly IApiProvider _apiProvider;
		private readonly string _weatherApiUrl;

		public WeatherStrategy()
		{
			var appConfig = new ModulesConfig();
			_weatherApiUrl = $"{appConfig.OpenWeatherUrl}?appid={appConfig.OpenWeatherKey}&units=metric";
		}

		public bool CanProcess(Message message)
		{
			return _triggerWords.Contains(message.Text.Split(' ').First().ToLower());
		}

		public MessageRequest Process(Message message)
		{
			return ProcessAsync(message).Result;
		}

		public async Task<MessageRequest> ProcessAsync(Message message)
		{
			var args = message.Text.Split(' ');
			var city = args.Length > 1 ? args[1] : "kharkiv";

			var content = await _weatherApiUrl.SetQueryParam("q", city).GetStringAsync();

			var data = content.FromJsonSnakeCase<WeatherResponse>();

			return new MessageRequest
			{
				ChatId = message.Chat.Id,
				Text = $"City\uD83C\uDF06: {data.Name}\r\nTemp\uD83C\uDF21: {data.Main.Temp}\r\nPressure: {data.Main.Pressure}\r\nMin Temp: {data.Main.TempMin}\r\nMax Temp: {data.Main.TempMax}",
			};
		}
	}
}
