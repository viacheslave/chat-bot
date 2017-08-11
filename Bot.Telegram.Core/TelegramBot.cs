using Bot.Common;
using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.Core.Models;
using Bot.Telegram.CoreAbstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Telegram.Core
{
	public class TelegramBot
	{
		private readonly int _pollingSleepTime;
		private readonly IList<IMessageProcessingStrategy> _processors;
		private readonly IApiProvider _apiProvider;

		protected TelegramBot()
		{
			_pollingSleepTime = 500;

			var appConfig = new AppConfig();
			_apiProvider = new ApiProvider(appConfig);
			_processors = new List<IMessageProcessingStrategy>();
		}

		public static TelegramBot Create() => new TelegramBot();

		public void AddModule<T>() where T : IMessageProcessingStrategy, new() => _processors.Add(new T());

		public async Task StartSafePollingAsync()
		{
			long offset = 0;
			IEnumerable<UpdateResultResponse> data = null;

			while (true)
			{
				data = (await _apiProvider.GetUpdatesAsync(offset)).Result.Where(i => i.UpdateId > offset);

				if (!data.Any())
					continue;

				if (offset != 0)
				{
					foreach (var item in data)
					{
						if (item.Message == null || string.IsNullOrEmpty(item.Message.Text))
							continue;

						var strategy = _processors.FirstOrDefault(s => s.CanProcess(item.Message));
						if (strategy == null)
							continue;

						try
						{
							var request = await strategy.ProcessAsync(item.Message);
							await _apiProvider.SendMessageAsync(request);
						}
						catch (System.Exception ex)
						{
						}
					}
				}

				offset = data.Last().UpdateId;
				Thread.Sleep(_pollingSleepTime);
			}
		}
	}
}
