using Bot.Common;
using Bot.Common.Serialization;
using Bot.Telegram.Core.Models;
using Bot.Telegram.CoreAbstraction;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace Bot.Telegram.Core
{
	internal class ApiProvider : IApiProvider
	{
		private readonly string _apiUrl; 

		public ApiProvider(IAppConfig appConfig)
		{
			_apiUrl = $"{appConfig.TelegramApiUrl}{appConfig.TelegramApiKey}";
		}

		public async Task<UpdatesResponse> GetUpdatesAsync(long offset)
		{
			var result = await _apiUrl
				.AppendPathSegment("/getUpdates")
				.SetQueryParam("offset", offset)
				.GetStringAsync();

			return result.FromJsonSnakeCase<UpdatesResponse>();
		}

		public async Task SendMessageAsync(MessageRequest messageRequest)
		{
			await _apiUrl
				.AppendPathSegment("/sendMessage")
				.PostJsonStringAsync(messageRequest.ToJsonSnakeCase());
		}
	}
}
