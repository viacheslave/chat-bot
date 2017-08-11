using Bot.Common;
using Bot.Telegram.Core.Abstraction;
using Bot.Telegram.CoreAbstraction;
using Bot.Telegram.Entities;
using System;
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
			IEnumerable<Update> data = null;

			while (true)
			{
				data = (await _apiProvider.GetUpdatesAsync(offset)).Result.Where(i => i.UpdateId > offset);

				if (!data.Any())
					continue;

				if (offset != 0)
				{
					foreach (var item in data)
					{
						if (item.Message == null)
							continue;

						var processingResults = _processors.Select(s => s.ProcessAsync(item.Message));
						if (!processingResults.Any())
							continue;

						try
						{
							foreach (var result in processingResults)
							{
								var request = await result;
								if (request == null)
									continue;

								await _apiProvider.SendMessageAsync(request);
							}
						}
						catch (Exception ex)
						{
							//TODO: add exception logging
						}
					}
				}

				offset = data.Last().UpdateId;
				Thread.Sleep(_pollingSleepTime);
			}
		}
	}
}
