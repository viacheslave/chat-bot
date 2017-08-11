using System;
using System.Configuration;

namespace Bot.Common
{
	public class AppConfig : IAppConfig
	{
		public string TelegramApiUrl => GetAppConfigValue("telegram.api.url");
		public string TelegramApiKey => GetAppConfigValue("telegram.token");

		protected string GetAppConfigValue(string key) => ConfigurationManager.AppSettings[key];
	}
}
