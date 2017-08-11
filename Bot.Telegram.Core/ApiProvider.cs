using Bot.Common;
using Bot.Common.Serialization;
using Bot.Telegram.Core.Abstraction;
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

		public async Task SendMessageAsync(IRequest messageRequest)
		{
			await _apiUrl
				.AppendPathSegment("/sendMessage")
				.PostJsonStringAsync(messageRequest.ToJsonSnakeCase());
		}

		public async Task EditMessageText(IRequest messageRequest)
		{
			await _apiUrl
				.AppendPathSegment("/editMessageText")
				.PostJsonStringAsync(messageRequest.ToJsonSnakeCase());
		}

		public async Task EditMessageReplyMarkup(IRequest messageRequest)
		{
			await _apiUrl
				.AppendPathSegment("/editMessageReplyMarkup")
				.PostJsonStringAsync(messageRequest.ToJsonSnakeCase());
		}
	}
}
